using Moq;
using SignupApp.API.DTOs;
using SignupApp.API.Models;
using Xunit;

namespace SignupApp.Tests
{
    public class AuthServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            _authService = new AuthService(_mockRepo.Object);
        }

        [Fact]
        public void Signup_Should_ReturnFalse_When_EmailInvalid()
        {
            var request = new SignupRequestDto
            {
                Email = "",
                Password = "12345678"
            };

            var result = _authService.Signup(request);

            Assert.False(result);
        }

        [Fact]
        public void Signup_Should_ReturnFalse_When_UserAlreadyExists()
        {
            var request = new SignupRequestDto
            {
                Email = "test@test.com",
                Password = "12345678"
            };

            _mockRepo
                .Setup(r => r.GetByEmail("test@test.com"))
                .Returns(new User());

            var result = _authService.Signup(request);

            Assert.False(result);
        }

        [Fact]
        public void Signup_Should_ReturnTrue_When_RequestValid()
        {
            var request = new SignupRequestDto
            {
                Email = "new@test.com",
                Password = "12345678"
            };

            _mockRepo
                .Setup(r => r.GetByEmail("new@test.com"))
                .Returns((User)null);

            var result = _authService.Signup(request);

            Assert.True(result);

            _mockRepo.Verify(r => r.Add(It.IsAny<User>()), Times.Once);
        }
    }
}