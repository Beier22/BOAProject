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
            return collection;
        }

        public bool DeleteCollection(int id)
        {
            var dispensableCollection = GetCollectionByID(id);
            _context.Attach(dispensableCollection).State = EntityState.Deleted;
            return true;
        }

        public IEnumerable<Collection> GetCollections()
        {
            return _context.Collections.AsNoTracking();
        }

        public Collection GetCollectionByID(int id)
        {
            return _context.Collections.AsNoTracking().FirstOrDefault(c => c.ID == id);
        }

        public Collection UpdateCollection(Collection collection)
        {
             _context.Attach(collection).State = EntityState.Modified;
            return collection;
        }
    }
}
