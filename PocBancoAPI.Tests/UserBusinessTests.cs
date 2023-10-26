using AutoMapper;
using Moq;
using PocBancoAPI.Business;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;

namespace PocBancoAPI.Tests
{
    [TestFixture]
    public class UserBusinessTests
    {
        private UserBusiness _userBusiness;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _userBusiness = new UserBusiness(_userRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetByEmail_ShouldReturnUserDTO_WhenValidEmailProvided()
        {
            // Arrange
            string email = "test@example.com";
            var user = new User { Email = email };
            var userDTO = new UserDTO { Email = email };
            _userRepositoryMock.Setup(r => r.GetByEmail(email)).ReturnsAsync(user);
            _mapperMock.Setup(m => m.Map<UserDTO>(user)).Returns(userDTO);

            // Act
            var result = await _userBusiness.GetByEmail(email);

            // Assert
            Assert.AreEqual(userDTO, result);
        }

        [Test]
        public async Task Insert_ShouldReturnUserId_WhenValidUserDTOProvided()
        {
            // Arrange
            var userDTO = new UserDTO { FirstName = "John", MiddleName = "Doe", LastName = "Smith", Email = "test@example.com", Document = "123456789" };
            var user = new User { FirstName = "John", MiddleName = "Doe", LastName = "Smith", Email = "test@example.com", Document = "123456789" };
            _mapperMock.Setup(m => m.Map<User>(userDTO)).Returns(user);
            _userRepositoryMock.Setup(r => r.Insert(user)).ReturnsAsync(1);

            // Act
            var result = await _userBusiness.Insert(userDTO);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task Update_ShouldReturnUpdatedUserDTO_WhenValidUserDTOProvided()
        {
            // Arrange
            var userDTO = new UserDTO { FirstName = "John", MiddleName = "Doe", LastName = "Smith", Email = "test@example.com", Document = "123456789" };
            var user = new User { FirstName = "John", MiddleName = "Doe", LastName = "Smith", Email = "test@example.com", Document = "123456789" };
            _mapperMock.Setup(m => m.Map<User>(userDTO)).Returns(user);
            _userRepositoryMock.Setup(r => r.Update(user)).ReturnsAsync(user);
            _mapperMock.Setup(m => m.Map<UserDTO>(user)).Returns(userDTO);

            // Act
            var result = await _userBusiness.Update(userDTO);

            // Assert
            Assert.AreEqual(userDTO, result);
        }
    }
}
