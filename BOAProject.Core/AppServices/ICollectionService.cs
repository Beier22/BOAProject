using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.AppServices
{
    public interface ICollectionService
    {
        IEnumerable<Collection> ReadCollection();
        Collection ReadCollectionByID(int id);
        Collection AddCollection(Collection collection);
        Collection ReviseCollection(Collection collection);
        bool RemoveCollection(int id);
    }
}
