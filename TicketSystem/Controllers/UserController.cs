using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketSystem.Data;
using TicketSystem.Models;
using TicketSystem.Repositories;
using TicketSystem.Repositories.Interface;
using TicketSystem.ViewModel;

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
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAll();
                return Ok(new { data = new { users } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ", error = ex.Message });

            }


        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);
                if (user == null)
                    return NotFound(new { message = $"Không tìm thấy User với ID = {id}" });

                return Ok(new { data = user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ", error = ex.Message });
            }
        }
        [HttpGet("Email")]
        [Authorize]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userRepository.GetByEmail(email);
                if (user == null)
                    return NotFound(new { message = $"Không tìm thấy User với Email  = {email}" });

                return Ok(new { data = user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ", error = ex.Message });
            }
        }
        [HttpGet("ByDepartment/{id}")]
        [Authorize(Roles="Employee,Manager")]
        public async Task<IActionResult> GetUserByDepartmentId(int id)
        {
            try
            {
                var users = await _userRepository.GetByDepartmentId(id);
                if (users == null)
                    return NotFound(new { message = $"Không tìm thấy User với DepartmentID = {id}" });

                return Ok(new { data = users });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ", error = ex.Message });
            }
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddUser(UserModel user)
        {
            try
            {
                if (user == null)
                    return BadRequest(new { message = "Dữ liệu không hợp lệ" });

                await _userRepository.Add(user);
                return Ok(new { message = "Thêm user thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi thêm user", error = ex.Message });
            }
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(UserVM user)
        {
            try
            {
                if (user == null)
                    return BadRequest(new { message = "Dữ liệu không hợp lệ" });

                await _userRepository.Update(user);
                return Ok(new { message = "Cập nhật user thành công" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật user", error = ex.Message });
            }
        }
        [HttpDelete("ByEmail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            try
            {
                var user = await _userRepository.GetByEmail(email);
                if (user == null)
                    return NotFound(new { message = $"Không tìm thấy User với Email = {email}" });

                await _userRepository.Delete(email);
                return Ok(new { message = "Xóa user thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi xóa user", error = ex.Message });
            }
        }
    }
}
