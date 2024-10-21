using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Data;
using TaskManager.Common.Models;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _dbContext;

        public UsersController(ApplicationContext db) { _dbContext = db; }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null) return BadRequest();
            _dbContext.Users.Add(new User(userDto));
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
