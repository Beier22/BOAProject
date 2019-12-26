using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.AppServices
{
    public interface IUserService
    {
        IEnumerable<User> ReadUsers();
        User ReadUserByID(int id);
        User AddUser(LoginInputModel input);
        User ReviseUser(User user);
        bool RemoveUser(int id);
    }
}
