using BOAProject.Core.DomainServices;
using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.AppServices.Implementation
{
    public class UserService: IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public User AddUser(User user)
        {
            return _userRepo.CreateUser(user);
        }

        public User ReadUserByID(int id)
        {
            return _userRepo.GetUserByID(id);
        }

        public IEnumerable<User> ReadUsers()
        {
            return _userRepo.GetUsers();
        }

        public bool RemoveUser(int id)
        {
            return _userRepo.DeleteUser(id);
        }

        public User ReviseUser(User user)
        {
            return _userRepo.UpdateUser(user);
        }
    }
}
