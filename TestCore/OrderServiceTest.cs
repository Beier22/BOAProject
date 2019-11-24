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

            var product = new Product()
            {
                Name = "Dirty Mads",
                Size = Size.XL,
                Type = "T-Shirt",
                AvailableQuantity = 1,
                Price = 99,
                Gender = "Female",
                Description = "Low quality T-Shirt worn by renowned Mads Beier on his alcoholic marathon JKJK."
            };
            var productList = new List<Product>();
            productList.Add(product);

            var order = new Order()
            {
                Products = productList,
                Total = 500.9,
                User = new User() { }, 
            };
            Exception ex = Assert.Throws<Exception>(() =>
                service.AddOrder(order));
            Assert.Equal("Address is required.", ex.Message);
        }

       

    }
}
