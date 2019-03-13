using CodingTestLuizaLabs.Business;
using CodingTestLuizaLabs.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WishesController : Controller
    {
        private readonly IWishBusiness _wishBusiness;

        public WishesController(IWishBusiness wishBusiness)
        {
            _wishBusiness = wishBusiness;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetPagedSearch(long userId, [FromQuery] int page_size, [FromQuery] int page)
        {
            return new OkObjectResult(_wishBusiness.FindWithPagedSearch(userId, page_size, page));
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(201, Type = typeof(Wish))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post(long userId, [FromBody]Wish[] wishes)
        {
            if (wishes == null) return BadRequest();
            return new OkObjectResult(_wishBusiness.Create(userId, wishes));
        }

        [HttpDelete("{userId}/{productId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long userId, long productId)
        {
            _wishBusiness.Delete(userId, productId);
            return NoContent();
        }
    }
}