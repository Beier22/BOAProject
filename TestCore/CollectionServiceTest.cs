using BOAProject.Core.AppServices;
using BOAProject.Core.AppServices.Implementation;
using BOAProject.Core.DomainServices;
using BOAProject.Core.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCore
{
    public class CollectionServiceTest
    {
        [Fact]
        public void CreateCollection_MissingName()
        {
            var collectionRepo = new Mock<ICollectionRepo>();

            ICollectionService service = new CollectionService(collectionRepo.Object);

            var collection = new Collection()
            {
                Name = ""
            };
            Exception ex = Assert.Throws<Exception>(() =>
                service.AddCollection(collection));
            Assert.Equal("Collection name is required.", ex.Message);
        }
        [Fact]
        public void DeleteCollection_WrongID()
        {
            var collectionRepo = new Mock<ICollectionRepo>();

            ICollectionService service = new CollectionService(collectionRepo.Object);

            Exception ex = Assert.Throws<Exception>(() =>
                service.RemoveCollection(0));
            Assert.Equal("Minimum ID is 1.", ex.Message);
        }

        [Fact]
        public void UpdateCollection_MissingName()
        {
            var collectionRepo = new Mock<ICollectionRepo>();

            ICollectionService service = new CollectionService(collectionRepo.Object);

            var collection = new Collection()
            {
                Name = ""
            };
            Exception ex = Assert.Throws<Exception>(() =>
                service.ReviseCollection(collection));
            Assert.Equal("Collection name is required.", ex.Message);
        }


    }
}
