using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Data;
using TaskManager.Common.Models;
using TaskManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _dbContext;

        public UsersController(ApplicationContext db) { _dbContext = db; }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            return await _dbContext.Users.Select(u => u.ToDto()).ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null) {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] UserDto userDto)
        {
            if (userDto == null) return BadRequest();
            _dbContext.Users.Add(new User(userDto));
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("create/all")]
        public async Task<IActionResult> CreateMultipleUsers([FromBody] List<UserDto> userDtoList)
        {
            if (userDtoList != null && userDtoList.Count > 0) {
                var newUsers = userDtoList.Select(ud => new User(ud));
                _dbContext.Users.AddRange(newUsers);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id) 
        {
            var findedUser = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (findedUser == null) {
                return NotFound();
            }
            _dbContext.Users.Remove(findedUser);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPatch("update/{id}")]
        public IActionResult Update(int id, [FromBody] UserDto userDto)
        {
            if (userDto != null) {
                var userForUpdate = _dbContext.Users.FirstOrDefault(ud => ud.Id == id);
                if (userForUpdate != null) {
                    userForUpdate.FirstName = userDto.FirstName;
                    userForUpdate.LastName = userDto.LastName;
                    userForUpdate.Email = userDto.Email;
                    userForUpdate.Password = userDto.Password;
                    userForUpdate.Phone = userDto.Phone;
                    userForUpdate.Status = userDto.Status;
                    userForUpdate.Photo = userDto.Photo;

                    _dbContext.Users.Update(userForUpdate);
                    _dbContext.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest();
        }

    }
}
