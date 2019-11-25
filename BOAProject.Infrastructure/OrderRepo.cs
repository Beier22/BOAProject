using BOAProject.Core.DomainServices;
using BOAProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOAProject.Infrastructure
{
    public class OrderRepo : IOrderRepo
    {
        private readonly BOAShopContext _context;

        public OrderRepo(BOAShopContext context)
        {
            _context = context;
        }
        public Order CreateOrder(Order order)
        {
            _context.Attach(order).State = EntityState.Added;
            _context.SaveChanges();
            return order;
        }

        public bool DeleteOrder(int id)
        {
            var dispensableOrder = GetOrderByID(id);
            _context.Attach(dispensableOrder).State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.AsNoTracking().Include(o => o.Address).Include(o => o.Products).Include(o => o.User);
        }

        public Order GetOrderByID(int id)
        {
            return _context.Orders.AsNoTracking().FirstOrDefault(c => c.ID == id);
        }

        public Order UpdateOrder(Order order)
        {
            _context.Attach(order).State = EntityState.Modified;
            _context.SaveChanges();
            return order;
        }
    }
}
