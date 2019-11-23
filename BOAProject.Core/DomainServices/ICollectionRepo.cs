using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.DomainServices
{
    public interface ICollectionRepo
    {
        IEnumerable<Collection> GetCollections();
        Collection GetCollectionByID(int id);
        Collection CreateCollection(Collection collection);
        Collection UpdateCollection(Collection collection);
        bool DeleteCollection(int id);
    }
}
