using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDPractice.Core;
using Xunit;
using Xunit.Abstractions;

namespace TDDPractice.Test.UserServiceTest
{
    public class Save
    {
        //private readonly ITestOutputHelper helper;
        private Mock<IRepository> repositoryMock;
        private UserService userService;

        public Save()
        {
            repositoryMock = new Mock<IRepository>();
            userService = new UserService(repositoryMock.Object);
        }

        [Fact]
        public void Should_Throw_NullException_WhenUserIsNull()
        {
            //Arrange
            var user = new User();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => userService.Save(user));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Throw_NullException_WhenLastNameIsNullOrEmpty(string input)
        {
            //Arrange
            var user = new User
            {
                LastName = input
            };

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => userService.Save(user));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Throw_NullException_WhenEmailAdressIsNullOrEmpty(string input)
        {
            //Arrange
            var user = new User
            {
                EmailAddress = input
            };

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => userService.Save(user));
        }

        [Theory]
        [InlineData("Een@test.nl")]
        [InlineData("Twee@test.nl")]
        public void Should_Throw_ArgumentException_WhenEmailAddress_AlreadyExcists(string email)
        {
            //Arrange
            var user = new User
            {
                LastName = "Cheenis",
                EmailAddress = email
            };

            repositoryMock.Setup(a => a.UserAlreadyExcists(user)).Returns(true);

            //Assert & Act
            Assert.Throws<ArgumentException>(() => userService.Save(user));
        }

        [Theory]
        [InlineData("geenapenstraartje")]
        [InlineData("gekemailadres.nl")]
        [InlineData("nieteenseenpunt@")]
        public void Should_Throw_ArgumentException_WhenEmailAddress_IsNotCorrect(string email)
        {
            //Arrange
            var user = new User
            {
                LastName = "Cheenis",
                EmailAddress = email
            };

            //Assert & Act
            Assert.Throws<ArgumentException>(() => userService.Save(user));
        }

        [Fact]
        public void Should_ReturnTrue_WhenUser_IsCorrect()
        {
            //Arrange
            var user = new User
            {
                LastName = "Cheenis",
                EmailAddress = "GoeieEmail@gmail.com",
                FirstName = "Henk"
            };

            //Act
            userService.Save(user);

            //Assert
            Assert.True(userService.Validate(user));
        }

        [Fact]
        public void Should_CallRepositoryAddMethodOnce_WhenUser_IsCorrect()
        {
            //Arrange
            var user = new User
            {
                LastName = "Cheenis",
                EmailAddress = "GoeieEmail@gmail.com",
                FirstName = "Henk"
            };

            //Act
            userService.Save(user);

            //Assert
            repositoryMock.Verify(r => r.Add(user), Times.Once);
        }
    }
}
