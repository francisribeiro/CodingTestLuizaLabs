using CodingTestLuizaLabs.Business;
using CodingTestLuizaLabs.Model;
using Microsoft.AspNetCore.Mvc;

namespace CodingTestLuizaLabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IBusiness<User> _userBusiness;

        public UserController(IBusiness<User> userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet("{page_size}/{page}")]
        public IActionResult GetPagedSearch([FromQuery] int pageSize, int page)
        {
            return new OkObjectResult(_userBusiness.FindWithPagedSearch(pageSize, page));
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null) return BadRequest();
            return new OkObjectResult(_userBusiness.Create(user));
        }

        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            if (user == null) return BadRequest();
            var updatedPerson = _userBusiness.Update(user);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody]User user)
        {
            if (user == null) return BadRequest();
            var updatedPerson = _userBusiness.Update(user);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userBusiness.Delete(id);
            return NoContent();
        }
    }
}