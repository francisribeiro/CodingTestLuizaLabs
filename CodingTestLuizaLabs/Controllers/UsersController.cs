using CodingTestLuizaLabs.Business;
using CodingTestLuizaLabs.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserBusiness _userBusiness;

        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<User>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetPagedSearch([FromQuery] int page_size, [FromQuery] int page)
        {
            return new OkObjectResult(_userBusiness.FindWithPagedSearch(page_size, page));
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null) return BadRequest();
            return new OkObjectResult(_userBusiness.Create(user));
        }

        [HttpPut]
        [ProducesResponseType(202, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody]User user)
        {
            if (user == null) return BadRequest();
            var updatedPerson = _userBusiness.Update(user);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _userBusiness.Delete(id);
            return NoContent();
        }
    }
}