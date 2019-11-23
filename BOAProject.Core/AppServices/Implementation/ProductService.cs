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
            return _productRepo.CreateProduct(product);
        }

        public Product ReadProductByID(int id)
        {
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
            return _productRepo.DeleteProduct(id);
        }

        public Product ReviseProduct(Product product)
        {
            return _productRepo.UpdateProduct(product);
        }
    }
}
