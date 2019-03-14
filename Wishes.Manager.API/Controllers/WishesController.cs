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

        /// <summary>
        /// Brings a list of whishes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="page_size">Page size</param>
        /// <param name="page">Page</param>
        /// <returns>List of wishes</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public IActionResult GetPagedSearch(long userId, [FromQuery] int page_size, [FromQuery] int page)
        {
            return new OkObjectResult(_wishBusiness.FindWithPagedSearch(userId, page_size, page));
        }

        /// <summary>
        /// Create a list of whishes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="wishes">Whishes list</param>
        /// <returns>Status code</returns>
        [HttpPost("{userId}")]
        [ProducesResponseType(201, Type = typeof(Wish))]
        [ProducesResponseType(400)]
        public IActionResult Post(long userId, [FromBody]Wish[] wishes)
        {
            if (wishes == null) return BadRequest();
            _wishBusiness.Create(userId, wishes);
            return StatusCode(201);
        }

        /// <summary>
        /// Delete a list item
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns>Status code</returns>
        [HttpDelete("{userId}/{productId}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(long userId, long productId)
        {
            _wishBusiness.Delete(userId, productId);
            return StatusCode(200);
        }
    }
}