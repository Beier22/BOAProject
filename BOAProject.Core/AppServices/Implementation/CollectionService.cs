using BOAProject.Core.DomainServices;
using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.AppServices.Implementation
{
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionRepo _collectionRepo;

        public CollectionService(ICollectionRepo collectionRepo)
        {
            _collectionRepo = collectionRepo;
        }

        public Collection AddCollection(Collection collection)
        {
            if (string.IsNullOrEmpty(collection.Name))
                throw new Exception("Collection name is required.");
            else
                return _collectionRepo.CreateCollection(collection);
        }

        public IEnumerable<Collection> ReadCollections()
        {
            return _collectionRepo.GetCollections();
        }

        public Collection ReadCollectionByID(int id)
        {
            if (id < 1)
                throw new Exception("Minimum ID is 1.");
            else
                return _collectionRepo.GetCollectionByID(id);
        }

        public bool RemoveCollection(int id)
        {
            if (id < 1)
                throw new Exception("Minimum ID is 1.");
            else
                return _collectionRepo.DeleteCollection(id);
        }

        public Collection ReviseCollection(Collection collection)
        {
            if (string.IsNullOrEmpty(collection.Name))
                throw new Exception("Collection name is required.");
            else
                return _collectionRepo.UpdateCollection(collection);
        }
    }
}
