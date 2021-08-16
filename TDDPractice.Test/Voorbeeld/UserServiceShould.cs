using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDPractice.Core;
using Xunit;
using Xunit.Abstractions;

namespace TDDPractice.Test
{
    public class UserServiceShould
    {
        private readonly ITestOutputHelper helper;

        private Mock<IRepository> repositoryMock;
        private UserService userService;
        public UserServiceShould(ITestOutputHelper helper)
        {
            this.helper = helper;
            repositoryMock = new Mock<IRepository>();
            userService = new UserService(repositoryMock.Object);
        }

        //[Fact]
        //public void Throw_ArgumentNullException_WhenUserIsNull()
        //{
        //    User user = null;

        //    Assert.Throws<ArgumentNullException>(() => userService.Save(user));
        //}

        //[Fact]
        //public void Call_RepositoryOnceOnSave()
        //{
        //    var user = new User();

        //    //repositoryMock.Setup(a => a.GetById(1)).Returns(new User { Id = 1,})
        //}
    }
}
