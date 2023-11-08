using AutoMapper;
using Moq;
using PocBancoAPI.Business;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;
using PocBancoAPI.Enums;
using PocBancoAPI.Services;
using PocBancoAPI.ViewModels.Filters;



namespace PocBancoAPI.Tests
{
    [TestFixture]
    public class AccountBusinessTests
    {
        private Mock<IAccountRepository> _mockAccountRepository;
        private Mock<IMapper> _mockMapper;
        private IAccountBusiness _accountBusiness;
        private object _mapper;

        [SetUp]
        public void Setup()
        {
            _mockAccountRepository = new Mock<IAccountRepository>();
            _mockMapper = new Mock<IMapper>();
            _accountBusiness = new AccountBusiness(_mockAccountRepository.Object, _mockMapper.Object);
        }


        [Test]
        public async Task GetAllAsync_ValidInput_ReturnsAccountDTOList()
        {
            // Arrange
            var filter = new AccountFilter();
            var accounts = new List<Account>
            {
                new Account
                {
                    IdAccount = 1,
                    IdUser = 1,
                    IsActive = true,
                    Balance = 1000.0m,
                    AccountType = AccountTypeEnum.PessoaJuridica,
                    FinancialOperations = new List<FinancialOperation>()
                }
            };

            _mockAccountRepository.Setup(x => x.GetAllAsync(It.IsAny<AccountFilter>())).ReturnsAsync(accounts);
            _mockMapper.Setup(x => x.Map<List<AccountDTO>>(accounts)).Returns(new List<AccountDTO> { new AccountDTO() });

            var accountBusiness = new AccountBusiness(_mockAccountRepository.Object, _mockMapper.Object);


            // Act
            var result = await accountBusiness.GetAllAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<AccountDTO>>(result);
        }

        [Test]
        public async Task GetByIdAsync_ValidInput_ReturnsAccountDTO()
        {
            // Arrange
            var accountId = 1;
            var account = new Account();
            _mockAccountRepository.Setup(x => x.GetByIdAsync(accountId)).ReturnsAsync(account);
            _mockMapper.Setup(x => x.Map<AccountDTO>(account)).Returns(new AccountDTO());

            // Act
            var result = await _accountBusiness.GetByIdAsync(accountId);

            // Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public async Task InsertAsync_ShouldReturnAccountId_WhenValidAccountDTOProvided()
        {
            // Arrange
            var accountDTO = new AccountDTO
            {
                IdAccount = 123,
                Balance = 1000,
                IdUser = 1
            };

            var account = new Account
            {
                IdAccount = 123,
                Balance = 1000,
                IdUser = 1
            };

            _mockMapper.Setup(m => m.Map<Account>(accountDTO)).Returns(account);
            _mockAccountRepository.Setup(r => r.InsertAsync(account)).ReturnsAsync(1);

            // Act
            var result = await _accountBusiness.InsertAsync(accountDTO);

            // Assert
            Assert.AreEqual(1, result);
        }


        [Test]
        public void InsertAsync_ShouldThrowException_WhenInvalidAccountDTOProvided()
        {
            // Arrange
            var accountDTO = new AccountDTO
            {
                IdAccount = 0,
                Balance = 1000,
                IdUser = 1
            };


            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _accountBusiness.InsertAsync(accountDTO));

        }

        [Test]
        public async Task UpdateAsync_ShouldUpdateAccount()
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mapperMock = new Mock<IMapper>();
            var accountBusiness = new AccountBusiness(accountRepositoryMock.Object, mapperMock.Object);

            var accountDTO = new AccountDTO
            {
                IdAccount = 1,
                IdUser = 1,
                Balance = 100,
                AccountType = AccountTypeEnum.PessoaFisica
            };

            var account = new Account
            {
                IdAccount = 1,
                IdUser = 1,
                Balance = 100,
                AccountType = AccountTypeEnum.PessoaFisica
            };

            accountRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Account>())).ReturnsAsync(1);
            accountRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(account);
            mapperMock.Setup(x => x.Map<AccountDTO>(It.IsAny<Account>())).Returns(accountDTO);

            // Act
            var result = await accountBusiness.UpdateAsync(accountDTO);

            // Assert
            Assert.AreEqual(accountDTO.IdAccount, result.IdAccount);
            Assert.AreEqual(accountDTO.IdUser, result.IdUser);
            Assert.AreEqual(accountDTO.Balance, result.Balance);
            Assert.AreEqual(accountDTO.AccountType, result.AccountType);
        }
    }
}





















