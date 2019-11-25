using BOAProject.Core.AppServices;
using BOAProject.Core.AppServices.Implementation;
using BOAProject.Core.DomainServices;
using BOAProject.Core.Entity;
using BOAProject.Infrastructure.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCore
{
    public class UserServiceTest
    {
        [Fact]
        public void CreateUser_MissingPassword()
        {   
            var userRepo = new Mock<IUserRepo>();
            IUserService service = new UserService(userRepo.Object);

            Byte[] password = new byte[40];
            Random rand = new Random();
            rand.NextBytes(password);

            var user = new User()
            {
                Email = "nicedude@gmail.com",
                PasswordSalt = password,
            };

            Exception ex = Assert.Throws<Exception>(() =>
                service.AddUser(user));
            Assert.Equal("Password is required.", ex.Message);
        }

        [Fact]
        public void FindUser_WrongID()
        {
            var userRepo = new Mock<IUserRepo>();

            IUserService service = new UserService(userRepo.Object);

            Exception ex = Assert.Throws<Exception>(() =>
                service.ReadUserByID(0));
            Assert.Equal("Minimum ID is 1.", ex.Message);
        }

        [Fact]
        public void DeleteUser_WrongID()
        {
            var userRepo = new Mock<IUserRepo>();

            IUserService service = new UserService(userRepo.Object);

            Exception ex = Assert.Throws<Exception>(() =>
                service.RemoveUser(0));
            Assert.Equal("Minimum ID is 1.", ex.Message);
        }

        [Fact]
        public void UpdateUser_MissingEmail()
        {
            var userRepo = new Mock<IUserRepo>();
            IUserService service = new UserService(userRepo.Object);

            Byte[] password = new byte[40];
            Random rand = new Random();
            rand.NextBytes(password);

            var user = new User()
            {
                PasswordHash = password,
                PasswordSalt = password,
            };

            Exception ex = Assert.Throws<Exception>(() =>
                service.ReviseUser(user));
            Assert.Equal("E-mail is required.", ex.Message);
        }


    }
}
