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
                return Ok(orders);
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
                return Ok(order);
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
                var o = _orderService.AddOrder(order);
                return Ok("Order succesfully created.");
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
                if (id == order.ID)
                {
                    var p = _orderService.ReviseOrder(order);
                    return Ok("Order successfully updated.");
                }
                else
                    return BadRequest("ID has to be the same with order ID");
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