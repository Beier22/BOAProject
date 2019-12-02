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
            return _context.Products.AsNoTracking().Include(p => p.Pictures).Include(p => p.Collection).FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.AsNoTracking().Include(p => p.SizeQuantity).Include(p => p.Collection);
        }
        public IEnumerable<Product> GetProductsFiltered(Filter filter)
        {
            
            if (filter.CurrentPage < 1)
                filter.CurrentPage = 1;
            if (filter.ItemsPrPage < 1)
                filter.ItemsPrPage = 12;

            IEnumerable<Product> allProducts = GetProducts();
            //If filter contains gender collection
            IEnumerable<Product> particularCollection = GetProductsByCollection(allProducts, filter);
            //If filter contains gender specification
            IEnumerable<Product> particularGender = GetProductsByGender(particularCollection, filter);
            //If filter contains both gender and type of the product
            IEnumerable<Product> particularGenderAndType = GetProductsByGenderAndType(particularGender, filter);



            IEnumerable<Product> filteredProducts = OrderProductsByPrice(particularGenderAndType, filter)

                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)

                .Take(filter.ItemsPrPage).ToList();

            return filteredProducts;
        }

        public Product UpdateProduct(Product product)
        {
            _context.Attach(product).State = EntityState.Modified;
            _context.SaveChanges();
            return product;
        }

        public IEnumerable<Product> OrderProductsByPrice(IEnumerable<Product> products, Filter filter)
        {
            switch (filter.Price)
            {
                case Price.asc:
                    return products.OrderBy(p => p.Price);
                case Price.dsc:
                    return products.OrderByDescending(p => p.Price);
            }
            return products;
        }


        public IEnumerable<Product> GetProductsByGender(IEnumerable<Product> products, Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.Gender))
                return products.Where(p => p.Gender !=null && p.Gender.ToLower().Equals(filter.Gender.ToLower()));
            else
                return products;
        }
        public IEnumerable<Product> GetProductsByGenderAndType(IEnumerable<Product> products, Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.Type))
                return products.Where(p => p.Type !=null &&  p.Type.ToLower().Equals(filter.Type.ToLower()));
            else
                return products;

        }
        public IEnumerable<Product> GetProductsByCollection(IEnumerable<Product> products, Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.Collection))
                return products.Where(p => p.Collection !=null && p.Collection.Name.ToLower().Equals(filter.Collection.ToLower()));
            else
                return products;
        }



    }
}