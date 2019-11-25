using BOAProject.Core.DomainServices;
using BOAProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOAProject.Infrastructure
{
    public class UserRepo : IUserRepo
    {
        private readonly BOAShopContext _context;

        public UserRepo(BOAShopContext context)
        {
            _context = context;
        }
        public User CreateUser(User user)
        {
            _context.Attach(user).State = EntityState.Added;
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            var dispensableUser = GetUserByID(id);
            _context.Attach(dispensableUser).State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }

        public User GetUserByID(int id)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.AsNoTracking().Include(u => u.Address).Include(u => u.Orders);
        }

        public User UpdateUser(User user)
        {
            _context.Attach(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }
    }
}
