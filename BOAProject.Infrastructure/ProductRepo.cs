using BOAProject.Core.DomainServices;
using BOAProject.Core.DomainServices.Filtering;
using BOAProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOAProject.Infrastructure
{
    public class ProductRepo : IProductRepo
    {
        private readonly BOAShopContext _context;

        public ProductRepo(BOAShopContext context)
        {
            _context = context;
        }
        public Product CreateProduct(Product product)
        {
            _context.Attach(product).State = EntityState.Added;
            _context.SaveChanges();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var dispensableProduct = GetProductByID(id);
            _context.Attach(dispensableProduct).State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }

        public Product GetProductByID(int id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.AsNoTracking().Include(p => p.Collection);
        }
        public IEnumerable<Product> GetProductsFiltered(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            _context.Attach(product).State = EntityState.Modified;
            _context.SaveChanges();
            return product;
        }
    }
}
