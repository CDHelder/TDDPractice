using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPractice.Core
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public void Save(User user)
        {
            if (Validate(user) == true)
                repository.Add(user);

        }

        public bool Validate(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.EmailAddress))
                throw new ArgumentNullException();

            if (repository.UserAlreadyExcists(user) == true)
                throw new ArgumentException();

            if (new EmailAddressAttribute().IsValid(user.EmailAddress) == false)
                throw new ArgumentException();

            return true;
        }
    }
}
