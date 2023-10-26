using AutoMapper;
using Moq;
using PocBancoAPI.Business;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;

namespace PocBancoAPI.Tests
{
    [TestFixture]
    public class FinancialOperationBusinessTests
    {
        private FinancialOperationBusiness _financialOperationBusiness;
        private Mock<IFinancialOperationRepository> _financialOperationRepositoryMock;
        private Mock<IAccountRepository> _accountRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _financialOperationRepositoryMock = new Mock<IFinancialOperationRepository>();
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _mapperMock = new Mock<IMapper>();
            _financialOperationBusiness = new FinancialOperationBusiness(
                _financialOperationRepositoryMock.Object,
                _accountRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Test]
        public async Task GetByIdAsync_ValidId_ReturnsFinancialOperationDTO()
        {
            // Arrange
            int id = 1;
            FinancialOperation financialOperation = new FinancialOperation { IdFinancialOperation = id };
            FinancialOperationDTO expected = new FinancialOperationDTO { IdFinancialOperation = id };

            _financialOperationRepositoryMock.Setup(repo => repo.GetByIdAsync(id))
                .ReturnsAsync(financialOperation);

            _mapperMock.Setup(m => m.Map<FinancialOperationDTO>(financialOperation))
                .Returns(expected);

            // Act
            FinancialOperationDTO result = await _financialOperationBusiness.GetByIdAsync(id);

            // Assert
            Assert.AreEqual(expected.IdFinancialOperation, result.IdFinancialOperation);
        }
    }
}
