using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDPractice.Core;
using Xunit;

namespace TDDPractice.FluentTest.UserServiceTest
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

            ////Act
            //Action action = () => userService.Save(user);
            ////Assert
            //action.Should().Throw<ArgumentNullException>();

            FluentActions.Invoking(() => userService.Save(user)).Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Throw_NullException_WhenLastNameIsNullOrEmpty(string input)
        {
            //Arrange
            var user = new User { LastName = input };

            ////Act
            //Action action = () => userService.Save(user);
            ////Assert
            //action.Should().Throw<ArgumentNullException>();

            FluentActions.Invoking(() => userService.Save(user)).Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Throw_NullException_WhenEmailAdressIsNullOrEmpty(string input)
        {
            //Arrange
            var user = new User { EmailAddress = input };

            ////Act
            //Action action = () => userService.Save(user);
            ////Assert
            //action.Should().Throw<ArgumentNullException>();

            FluentActions.Invoking(() => userService.Save(user)).Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("Een@test.nl")]
        [InlineData("Twee@test.nl")]
        public void Should_Throw_ArgumentException_WhenEmailAddress_AlreadyExcists(string email)
        {
            //Arrange
            var user = new User { LastName = "Cheenis", EmailAddress = email };

            repositoryMock.Setup(a => a.UserAlreadyExcists(user)).Returns(true);

            ////Act
            //Action action = () => userService.Save(user);
            ////Assert
            //action.Should().Throw<ArgumentException>();

            FluentActions.Invoking(() => userService.Save(user)).Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("geenapenstraartje")]
        [InlineData("gekemailadres.nl")]
        [InlineData("nieteenseenpunt@")]
        public void Should_Throw_ArgumentException_WhenEmailAddress_IsNotCorrect(string email)
        {
            //Arrange
            var user = new User{ LastName = "Cheenis", EmailAddress = email };

            ////Act
            //Action action = () => userService.Save(user);
            ////Assert
            //action.Should().Throw<ArgumentException>();

            FluentActions.Invoking(() => userService.Save(user)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Should_ReturnTrue_WhenUser_IsCorrect()
        {
            //Arrange
            var user = new User { LastName = "Cheenis", EmailAddress = "GoeieEmail@gmail.com", FirstName = "Henk" };

            ////Act
            //var result = userService.Validate(user);
            ////Assert
            //result.Should().BeTrue();

            FluentActions.Invoking(() => userService.Validate(user)).Should().Equals(true);
        }

        [Fact]
        public void Should_CallRepositoryAddMethodOnce_WhenUser_IsCorrect()
        {
            //Arrange
            var user = new User { LastName = "Cheenis", EmailAddress = "GoeieEmail@gmail.com", FirstName = "Henk"};

            //Act
            userService.Save(user);

            //Assert
            repositoryMock.Verify(r => r.Add(user), Times.Once);
        }   
    }
}
