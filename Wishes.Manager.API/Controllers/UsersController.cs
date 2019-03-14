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

        /// <summary>
        /// Brings a list of users
        /// </summary>
        /// <param name="page_size"></param>
        /// <param name="page"></param>
        /// <returns>List of users</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<User>))]
        public IActionResult GetPagedSearch([FromQuery] int page_size, [FromQuery] int page)
        {
            return new OkObjectResult(_userBusiness.FindWithPagedSearch(page_size, page));
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>Status code</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null) return BadRequest();
            _userBusiness.Create(user);
            return StatusCode(201);
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>Status code</returns>
        [HttpPut]
        [ProducesResponseType(202, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody]User user)
        {
            if (user == null) return BadRequest();
            var updatedPerson = _userBusiness.Update(user);
            if (updatedPerson == null) return BadRequest();
            return StatusCode(202);
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Status code</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(int id)
        {
            _userBusiness.Delete(id);
            return StatusCode(200);
        }
    }
}