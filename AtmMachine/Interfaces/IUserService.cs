using AtmMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtmMachine.Interface
{
    public interface IUserService
    {
        User AddUser(User user);
        User UpdateUser(User user);
        void RemoveUser(int userId);
        User LogInUser(User user);
    }
}
