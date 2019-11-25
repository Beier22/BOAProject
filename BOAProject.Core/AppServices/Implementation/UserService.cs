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
            if (string.IsNullOrEmpty(user.Email))
                throw new Exception("E-mail is required.");
            else if (user.PasswordHash == null)
                throw new Exception("Password is required.");
            else if (user.PasswordSalt == null)
                throw new Exception("Salt is required.");
            else
                return _userRepo.CreateUser(user);
        }

        public User ReadUserByID(int id)
        {
            if (id <= 0)
                throw new Exception("Minimum ID is 1.");
            else
                return _userRepo.GetUserByID(id);
        }

        public IEnumerable<User> ReadUsers()
        {
            return _userRepo.GetUsers();
        }

        public bool RemoveUser(int id)
        {
            if (id <= 0)
                throw new Exception("Minimum ID is 1.");
            else
                return _userRepo.DeleteUser(id);
        }

        public User ReviseUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
                throw new Exception("E-mail is required.");
            else if (user.PasswordHash == null)
                throw new Exception("Password is required.");
            else if (user.PasswordSalt == null)
                throw new Exception("Salt is required.");
            else
                return _userRepo.UpdateUser(user);
        }
    }
}
