using CodingTestLuizaLabs.Business;
using CodingTestLuizaLabs.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetPagedSearch([FromQuery] int page_size, [FromQuery] int page)
        {
            return new OkObjectResult(_productBusiness.FindWithPagedSearch(page_size, page));
        }

        [HttpPost]
        [ProducesResponseType(202, Type = typeof(Product))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            return new OkObjectResult(_productBusiness.Create(product));
        }

        [HttpPut]
        [ProducesResponseType(202, Type = typeof(Product))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            var updatedPerson = _productBusiness.Update(product);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            return NoContent();
        }
    }
}