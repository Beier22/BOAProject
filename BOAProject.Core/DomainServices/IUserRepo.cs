using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.DomainServices
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
