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
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            try
            {
                var orders = _orderService.ReadOrders();
                if (orders.Any())
                    return Ok(orders);
                else
                    return Ok("No orders found.");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {

            try
            {
                var order = _orderService.ReadOrderByID(id);
                if (order != null)
                    return Ok(order);
                else
                    return Ok($"Order with ID: {id} doens't exist.");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            try
            {
                if (order.Address == null)
                    return BadRequest("Address is required.");
                else if (order.Products.Count == 0)
                    return BadRequest("Order must have at least one product.");
                else if (order.User == null)
                    return BadRequest("Order must have a User.");
                else if (order.Total <= 0)
                    return BadRequest("Total value is wrong.");
                else
                {
                    var o = _orderService.AddOrder(order);
                    return Ok("Order succesfully created.");
                }
                 
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            try
            {
                if (id != order.ID)
                    return BadRequest("ID and Order ID has to be the same.");
                else if (order.Address == null)
                    return BadRequest("Address is required.");
                else if (order.Products.Count == 0)
                    return BadRequest("Order must have at least one product.");
                else if (order.User == null)
                    return BadRequest("Order must have a User.");
                else if (order.Total <= 0)
                    return BadRequest("Total value is wrong.");
                else
                {
                    var p = _orderService.ReviseOrder(order);
                    return Ok("Order successfully created.");
                }
            }                    
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {

            try
            {
                var userToRemove = _orderService.ReadOrderByID(id);
                if (userToRemove != null)
                {
                    _orderService.RemoveOrder(id);
                    return Ok("Order successfully removed.");
                }
                else
                    return BadRequest("Order doesn't exist");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
    }
}