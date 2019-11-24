using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOAProject.Core.AppServices;
using BOAProject.Core.DomainServices.Filtering;
using BOAProject.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BOAProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                var products = _userService.ReadUsers();
                return Ok(products);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {

            try
            {
                var product = _userService.ReadUserByID(id);
                return Ok(product);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                var p = _userService.AddUser(user);
                return Ok("User succesfully created.");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            try
            {
                if (id == user.ID)
                {
                    var p = _userService.ReviseUser(user);
                    return Ok("User successfully updated.");
                }
                else
                    return BadRequest("ID has to be the same with user ID");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {

            try
            {
                var userToRemove = _userService.ReadUserByID(id);
                if (userToRemove != null)
                {
                    _userService.RemoveUser(id);
                    return Ok("User successfully removed.");
                }
                else
                    return BadRequest("User doesn't exist");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
    }
}