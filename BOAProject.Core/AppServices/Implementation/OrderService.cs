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
            if (order.Address == null)
                throw new Exception("Address is required.");
            else if(order.Products.Count == 0)
                throw new Exception("Order must have at least one product.");
            else if(order.User == null)
                throw new Exception("Order must have a User.");
            else if(order.Total <= 0)
                throw new Exception("Total value is wrong.");
            else
                return _orderRepo.CreateOrder(order);
        }

        public IEnumerable<Order> ReadOrders()
        {
            return _orderRepo.GetOrders();
        }

        public Order ReadOrderByID(int id)
        {
            if (id <= 0)
                throw new Exception("Minimum ID is 1.");
            else
                return _orderRepo.GetOrderByID(id);
        }

        public bool RemoveOrder(int id)
        {
            if (id <= 0)
                throw new Exception("Minimum ID is 1.");
            else
                return _orderRepo.DeleteOrder(id);
        }

        public Order ReviseOrder(Order order)
        {
            if (order.Address == null)
                throw new Exception("Address is required.");
            else if (order.Products.Count == 0)
                throw new Exception("Order must have at least one product.");
            else if (order.User == null)
                throw new Exception("Order must have a User.");
            else if (order.Total <= 0)
                throw new Exception("Total value is wrong.");
            else
                return _orderRepo.UpdateOrder(order);
        }
    }
}
