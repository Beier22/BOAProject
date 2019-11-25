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
                return Ok(collections);
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
                return Ok(collection);
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
                var o = _collectionService.AddCollection(collection);
                return Ok("Collection succesfully created.");
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
                if (id == collection.ID)
                {
                    var p = _collectionService.ReviseCollection(collection);
                    return Ok("Collection successfully updated.");
                }
                else
                    return BadRequest("ID has to be the same with collection ID");
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