using CodingTestLuizaLabs.Business;
using CodingTestLuizaLabs.Model;
using Microsoft.AspNetCore.Mvc;

namespace CodingTestLuizaLabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IBusiness<Product> _productBusiness;

        public ProductController(IBusiness<Product> productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpGet("{page_size}/{page}")]
        public IActionResult GetPagedSearch([FromQuery] int pageSize, int page)
        {
            return new OkObjectResult(_productBusiness.FindWithPagedSearch(pageSize, page));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            return new OkObjectResult(_productBusiness.Create(product));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            var updatedPerson = _productBusiness.Update(product);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            var updatedPerson = _productBusiness.Update(product);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            return NoContent();
        }
    }
}