using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.AppServices
{
    public interface IProductService
    {
        IEnumerable<Product> ReadProducts(Filter filter);
        Product ReadProductByID(int id);
        Product AddProduct(Product product);
        Product ReviseProduct(Product product);
        bool RemoveProduct(int id);
    }
}
