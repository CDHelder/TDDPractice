using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPractice
{
    public interface IRepository
    {
        User GetById(int id);
        List<User> GetAll();
        void Update(User obj);
        void Delete(int id);
        void Delete(User obj);
        void Add(User obj);
        bool UserAlreadyExcists(User user);


    }
}
