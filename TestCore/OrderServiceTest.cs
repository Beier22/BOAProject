using BOAProject.Core.AppServices;
using BOAProject.Core.AppServices.Implementation;
using BOAProject.Core.DomainServices;
using BOAProject.Core.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCore
{
    public class OrderServiceTest
    {

        [Fact]
        public void CreateOrder_MissingAddress()
        {
            var orderRepo = new Mock<IOrderRepo>();
            
            IOrderService service = new OrderService(orderRepo.Object);

            var order = new Order()
            {
                Products = new List<ProductQuantity>(),
                Total = 500.9,
                User = new User() { }, 
            };
            Exception ex = Assert.Throws<Exception>(() =>
                service.AddOrder(order));
            Assert.Equal("Address is required.", ex.Message);
        }


        [Fact]
        public void DeleteOrder_WrongID()
        {
            var orderRepo = new Mock<IOrderRepo>();

            IOrderService service = new OrderService(orderRepo.Object);

            Exception ex = Assert.Throws<Exception>(() =>
                service.RemoveOrder(0));
            Assert.Equal("Minimum ID is 1.", ex.Message);
        }

        [Fact]
        public void FindOrder_WrongID()
        {
            var orderRepo = new Mock<IOrderRepo>();

            IOrderService service = new OrderService(orderRepo.Object);

            Exception ex = Assert.Throws<Exception>(() =>
                service.ReadOrderByID(-100));
            Assert.Equal("Minimum ID is 1.", ex.Message);
        }

        [Fact]
        public void UpdateOrder_MissingUser()
        {
            var orderRepo = new Mock<IOrderRepo>();

            IOrderService service = new OrderService(orderRepo.Object);

            var order = new Order()
            {
                Address = new Address(),
                Products = new List<ProductQuantity>() { new ProductQuantity() },
                Total = 500.9,
            };
            Exception ex = Assert.Throws<Exception>(() =>
                service.AddOrder(order));
            Assert.Equal("Order must have a User.", ex.Message);
        }

    }
}
