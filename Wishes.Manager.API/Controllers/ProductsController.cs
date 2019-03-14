using CodingTestLuizaLabs.Business;
using CodingTestLuizaLabs.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductBusiness _productBusiness;

        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        /// <summary>
        /// Brings a list of products
        /// </summary>
        /// <param name="page_size"></param>
        /// <param name="page"></param>
        /// <returns>List of products</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public IActionResult GetPagedSearch([FromQuery] int page_size, [FromQuery] int page)
        {
            return new OkObjectResult(_productBusiness.FindWithPagedSearch(page_size, page));
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="product">Product entity</param>
        /// <returns>Status code</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            _productBusiness.Create(product);
            return StatusCode(201);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product">Product entity</param>
        /// <returns>Status code</returns>
        [HttpPut]
        [ProducesResponseType(202, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            var updatedPerson = _productBusiness.Update(product);
            if (updatedPerson == null) return BadRequest();
            return StatusCode(202);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Status code</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            return StatusCode(200);
        }
    }
}