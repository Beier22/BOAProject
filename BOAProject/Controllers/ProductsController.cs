﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOAProject.Core.AppServices;
using BOAProject.Core.DomainServices.Filtering;
using BOAProject.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOAProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get([FromQuery] Filter filter)
        {
            try
            {
                var products = _productService.ReadProducts(filter);
                return Ok(products);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
    

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {

            try
            {
                var product = _productService.ReadProductByID(id);
                return Ok(product);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            
            }

        // POST api/values
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            try
            {
                var p = _productService.AddProduct(product);
                return Ok("Product succesfully created.");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product product)
        {
            try
            {
                if (id == product.ID)
                {
                    var p = _productService.ReviseProduct(product);
                    return Ok("Product successfully updated.");
                }
                else
                    return BadRequest("ID has to be the same with product ID");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            
            try
            {
                var productToRemove = _productService.ReadProductByID(id);
                if (productToRemove != null)
                {
                    _productService.RemoveProduct(id);
                    return Ok("Product successfully removed.");
                }
                else
                    return BadRequest("Product doesn't exist");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
    }
}