using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.DomainServices
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int id);
        Order CreateOrder(Order order);
        Order UpdateOrder(Order order);
        bool DeleteOrder(int id);
    }
}
