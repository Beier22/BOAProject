using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOAProject.Core.AppServices;
using BOAProject.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BOAProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionService _collectionService;

        public CollectionsController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Collection>> Get()
        {
            try
            {
                var collections = _collectionService.ReadCollections();
                if (collections.Any())
                    return Ok(collections);
                else
                    return Ok("No collections found.");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Collection> Get(int id)
        {

            try
            {
                var collection = _collectionService.ReadCollectionByID(id);
                if (collection != null)
                    return Ok(collection);
                else
                    return BadRequest($"Collection with ID: {id} doesn't exist.");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult<Collection> Post([FromBody] Collection collection)
        {
            try
            {
                if (string.IsNullOrEmpty(collection.Name))
                    return BadRequest("Collection name is required.");
                else
                {
                    var o = _collectionService.AddCollection(collection);
                    return Ok("Collection succesfully created.");
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Collection> Put(int id, [FromBody] Collection collection)
        {
            try
            {
                if (id != collection.ID)
                    return BadRequest("ID has to be the same with collection ID");
                else if (string.IsNullOrEmpty(collection.Name))
                    throw new Exception("Collection name is required.");
                else
                {
                    var p = _collectionService.ReviseCollection(collection);
                    return Ok("Collection successfully updated.");
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Collection> Delete(int id)
        {

            try
            {
                var userToRemove = _collectionService.ReadCollectionByID(id);
                if (userToRemove != null)
                {
                    _collectionService.RemoveCollection(id);
                    return Ok("Collection successfully removed.");
                }
                else
                    return BadRequest("Collection doesn't exist");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
    }
}