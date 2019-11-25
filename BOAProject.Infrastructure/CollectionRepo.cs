using BOAProject.Core.DomainServices;
using BOAProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOAProject.Infrastructure
{
    public class CollectionRepo : ICollectionRepo
    {
        private readonly BOAShopContext _context;

        public CollectionRepo(BOAShopContext context)
        {
            _context = context;
        }
        public Collection CreateCollection(Collection collection)
        {
            _context.Attach(collection).State = EntityState.Added;
            _context.SaveChanges();
            return collection;
        }

        public bool DeleteCollection(int id)
        {
            var dispensableCollection = GetCollectionByID(id);
            _context.Attach(dispensableCollection).State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Collection> GetCollections()
        {
            return _context.Collections.AsNoTracking().Include(c => c.Products);
        }

        public Collection GetCollectionByID(int id)
        {
            return _context.Collections.AsNoTracking().Include(c => c.Products).FirstOrDefault(c => c.ID == id);
        }

        public Collection UpdateCollection(Collection collection)
        {
             _context.Attach(collection).State = EntityState.Modified;
            _context.SaveChanges();
            return collection;
        }
    }
}
