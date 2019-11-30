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
    public class ProductServiceTest
    {
        [Fact]
        public void CreateProduct_TypeMissing()
        {
            var productRepo = new Mock<IProductRepo>();

            IProductService service = new ProductService(productRepo.Object);

            Product p = new Product()
            {
                Name = "Dirty Mads",
                SizeQuantity = new List<SizeQuantity>(),
                Price = 99,
                Gender = "Female",
                Description = "Low quality T-Shirt worn by renowned Mads Beier on his alcoholic marathon JKJK."
            };

            Exception ex = Assert.Throws<Exception>(() =>
                service.AddProduct(p));
            Assert.Equal("Type of the product is required.", ex.Message);
        }

        [Fact]
        public void FindProduct_WrongID()
        {
            var productRepo = new Mock<IProductRepo>();

            IProductService service = new ProductService(productRepo.Object);

            Exception ex = Assert.Throws<Exception>(() =>
                service.ReadProductByID(-1));
            Assert.Equal("Minimum ID is 1.", ex.Message);
        }

        [Fact]
        public void FindDelete_WrongID()
        {
            var productRepo = new Mock<IProductRepo>();

            IProductService service = new ProductService(productRepo.Object);

            Exception ex = Assert.Throws<Exception>(() =>
                service.RemoveProduct(-1));
            Assert.Equal("Minimum ID is 1.", ex.Message);
        }

        [Fact]
        public void UpdateProduct_WrongPrice()
        {
            var productRepo = new Mock<IProductRepo>();

            IProductService service = new ProductService(productRepo.Object);

            Product p = new Product()
            {
                Name = "Dirty Mads",
                SizeQuantity = new List<SizeQuantity>(),

                Type = "T-Shirt",
                Price = 0,
                Gender = "Female",
                Description = "Low quality T-Shirt worn by renowned Mads Beier on his alcoholic marathon JKJK."
            };

            Exception ex = Assert.Throws<Exception>(() =>
                service.AddProduct(p));
            Assert.Equal("Price of the product is wrong.", ex.Message);
        }

    }
}
