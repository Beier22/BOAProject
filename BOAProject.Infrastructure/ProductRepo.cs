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
            return _context.Products.Include(p => p.Pictures).Include(p => p.Collection).FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(p => p.SizeQuantity).Include(p => p.Collection).Include(p => p.Pictures);
        }
        public IEnumerable<Product> GetProductsFiltered(Filter filter)
        {
            
            if (filter.CurrentPage < 1)
                filter.CurrentPage = 1;
            if (filter.ItemsPrPage < 1)
                filter.ItemsPrPage = 12;

            var allProducts = GetProducts();
            //If filter contains gender collection
            var particularCollection = GetProductsByCollection(allProducts, filter);
            //If filter contains gender specification
            var particularGender = GetProductsByGender(particularCollection, filter);
            //If filter contains both gender and type of the product
            var particularGenderAndType = GetProductsByGenderAndType(particularGender, filter);



            var filteredProducts = OrderProductsByPrice(particularGenderAndType, filter)

                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)

                .Take(filter.ItemsPrPage).ToList();

            return filteredProducts;
        }

        public Product UpdateProduct(Product product)
        {
            if(product.Collection == null)
            {
                _context.Entry(product).Reference(p => p.Collection).IsModified = true;
            }
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
            IEnumerable<Product> genderSpecific;
            IEnumerable<Product> unisex;
            if (!string.IsNullOrEmpty(filter.Gender))
            {
                    genderSpecific = products.Where(p => p.Gender != null && p.Gender.ToLower().Equals(filter.Gender.ToLower()));
                    unisex = products.Where(p => p.Gender != null && p.Gender.ToLower().Equals("unisex"));
                
                return genderSpecific.Concat(unisex);
            }
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