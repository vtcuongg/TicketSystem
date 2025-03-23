using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Data;
using TicketSystem.Models;
using TicketSystem.Repositories;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id )
        {
            var user = await _userRepository.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel user)
        {
            await _userRepository.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserID }, user);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id ,UserVM user)
        {
            if (id != user.UserID) return BadRequest();
            await _userRepository.Update(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.Delete(id);
            return NoContent();
        }
    } 
}
