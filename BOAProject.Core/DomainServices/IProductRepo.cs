using BOAProject.Core.DomainServices.Filtering;
using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.DomainServices
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsFiltered(Filter filter);
        Product GetProductByID(int id);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        bool DeleteProduct(int id);
        IEnumerable<Product> OrderProducts(IEnumerable<Product> products, Filter filter);

    }
}
