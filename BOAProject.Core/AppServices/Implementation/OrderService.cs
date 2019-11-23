using BOAProject.Core.DomainServices;
using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.AppServices.Implementation
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Order AddOrder(Order order)
        {
            return _orderRepo.CreateOrder(order);
        }

        public IEnumerable<Order> ReadOrders()
        {
            return _orderRepo.GetOrders();
        }

        public Order ReadOrderByID(int id)
        {
            return _orderRepo.GetOrderByID(id);
        }

        public bool RemoveOrder(int id)
        {
            return _orderRepo.DeleteOrder(id);
        }

        public Order ReviseOrder(Order order)
        {
            return _orderRepo.UpdateOrder(order);
        }
    }
}
