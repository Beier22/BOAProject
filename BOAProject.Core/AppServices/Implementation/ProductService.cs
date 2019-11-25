using BOAProject.Core.DomainServices;
using BOAProject.Core.DomainServices.Filtering;
using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.AppServices.Implementation
{
    public class ProductService: IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public Product AddProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
                throw new Exception("Name of the product is required.");
            else if (string.IsNullOrEmpty(product.Description))
                throw new Exception("Description of the product is required.");
            else if (string.IsNullOrEmpty(product.Type))
                throw new Exception("Type of the product is required.");
            else if (product.AvailableQuantity < 0)
                throw new Exception("Quantity of the product is wrong.");
            else if (product.Price <= 0)
                throw new Exception("Price of the product is wrong.");
            else if (product.DiscountPrice < 0)
                throw new Exception("Discount price of the product is wrong.");
            else 
                return _productRepo.CreateProduct(product);
        }

        public Product ReadProductByID(int id)
        {
            if (id <= 0)
                throw new Exception("Minimum ID is 1.");
            else
                return _productRepo.GetProductByID(id);
        }

        public IEnumerable<Product> ReadProducts(Filter filter)
        {
            if (filter.ItemsPrPage < 1 || filter.CurrentPage < 1)
                return _productRepo.GetProducts();
            else
                return _productRepo.GetProductsFiltered(filter);
        }

        public bool RemoveProduct(int id)
        {
            if (id <= 0)
                throw new Exception("Minimum ID is 1.");
            else
                return _productRepo.DeleteProduct(id);
        }

        public Product ReviseProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
                throw new Exception("Name of the product is required.");
            else if (string.IsNullOrEmpty(product.Description))
                throw new Exception("Description of the product is required.");
            else if (string.IsNullOrEmpty(product.Type))
                throw new Exception("Type of the product is required.");
            else if (product.AvailableQuantity < 0)
                throw new Exception("Quantity of the product is wrong.");
            else if (product.Price <= 0)
                throw new Exception("Price of the product is wrong.");
            else if (product.DiscountPrice < 0)
                throw new Exception("Discount price of the product is wrong.");
            else
                return _productRepo.UpdateProduct(product);
        }
    }
}
