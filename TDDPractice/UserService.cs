using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPractice.Core
{
    public class UserService : IUserService
    {
        private readonly Repository repository;

        public UserService(Repository repository)
        {
            this.repository = repository;
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }

        public bool Validate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
