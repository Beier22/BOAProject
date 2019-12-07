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
            if (collection.Products != null)
            {
                _context.AttachRange(collection.Products);
            }
            _context.Add(collection);
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
            return _context.Collections.Include(c => c.Products).ThenInclude(pr => pr.Pictures);
        }

        public Collection GetCollectionByID(int id)
        {
            return _context.Collections.Include(c => c.Products).FirstOrDefault(c => c.ID == id);
        }

        public Collection UpdateCollection(Collection collection)
        {
            if (collection.Products == null)
            {
                _context.Entry(collection).Reference(c => c.Products).IsModified = true;
            } 
            _context.Attach(collection).State = EntityState.Modified;
            _context.SaveChanges();
            return collection;
        }
    }
}
