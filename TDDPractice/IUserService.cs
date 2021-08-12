using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPractice
{
    interface IUserService
    {
        void Save(User user);
        bool Validate(User user);
    }
}
