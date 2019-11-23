using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.AppServices
{
    public interface IOrderService
    {
        IEnumerable<Order> ReadOrders();
        Order ReadOrderByID(int id);
        Order AddOrder(Order order);
        Order ReviseOrder(Order order);
        bool RemoveOrder(int id);
    }
}
