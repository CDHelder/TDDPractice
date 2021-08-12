using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDPractice.Core;
using Xunit;

namespace TDDPractice.Test.UserServiceTest
{
    public class Save
    {
        [Fact]
        public void Should_Throw_NullException_WhenUserIsNull()
        {
            //Arrange
            var mockRepo = new Mock<Repository>();
            var mockUserService = new UserService(mockRepo.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => mockUserService.Save(null));
        }
    }
}
