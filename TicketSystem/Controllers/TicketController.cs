﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Repositories.Interface;
using TicketSystem.ViewModel;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository ticketRepository)
        {
            this._ticketRepository = ticketRepository;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllTicket()
        //{
        //    try
        //    {
        //        var tickets = await _ticketRepository.GetAll();
        //        return Ok(new { data = tickets });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Lỗi khi lấy danh sách Ticket", error = ex.Message });
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetTicketById(int id)
        //{
        //    try
        //    {
        //        var ticket = await _ticketRepository.GetById(id);
        //        if (ticket == null)
        //            return NotFound(new { message = $"Không tìm thấy Ticket với ID = {id}" });

        //        return Ok(new { data = ticket });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Lỗi khi lấy Ticket", error = ex.Message });
        //    }
        //}

        //[HttpGet("ByUser/{UserId}")]
        //public async Task<IActionResult> GetTicketByUserId(int UserId)
        //{
        //    try
        //    {
        //        var tickets = await _ticketRepository.GetByUserId(UserId);
        //        if (tickets == null || !tickets.Any())
        //            return NotFound(new { message = $"Không tìm thấy Ticket nào cho UserID = {UserId}" });

        //        return Ok(new { data = tickets });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Lỗi khi lấy Ticket theo UserID", error = ex.Message });
        //    }
        //}
        [HttpGet("ByDepartmentId/{DepartmentId}")]
        public async Task<IActionResult> GetTicketByDepartmentId(int DepartmentId)
        {
            try
            {
                var tickets = await _ticketRepository.GetByDepartmentId(DepartmentId);
                if (tickets == null || !tickets.Any())
                    return NotFound(new { message = $"Không tìm thấy Ticket nào cho phòng ban có ID = {DepartmentId}" });

                return Ok(new { data = tickets });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy Ticket theo DepartmentID", error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketVM ticket)
        {
            try
            {
                if (ticket == null)
                    return BadRequest(new { message = "Dữ liệu không hợp lệ" });

                await _ticketRepository.Add(ticket);
                return Ok(new { message = "Thêm Ticket thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi thêm Ticket", error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicket(TicketVM ticket)
        {
            try
            {
                if (ticket == null)
                    return BadRequest(new { message = "Dữ liệu không hợp lệ" });

                await _ticketRepository.Update(ticket);
                return Ok(new { message = "Cập nhật Ticket thành công" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật Ticket", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(string id)
        {
            try
            {
                var ticket = await _ticketRepository.GetById(id);
                if (ticket == null)
                    return NotFound(new { message = $"Không tìm thấy Ticket với ID = {id}" });

                await _ticketRepository.Delete(id);
                return Ok(new { message = "Xóa Ticket thành công" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi xóa Ticket", error = ex.Message });
            }
        }
        [HttpPatch("Status")]
        public async Task<IActionResult> UpdateTicketStatus(string TicketId, [FromBody] string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
            {
                return BadRequest("Trạng thái không hợp lệ.");
            }
            try
            {
                await _ticketRepository.UpdateStatus(TicketId, newStatus);
                return Ok(new { message = "Cập nhật thành công" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch("Priority")]
        public async Task<IActionResult> UpdatePriority(string TicketId, [FromBody] string newPriority)
        {
            if (string.IsNullOrWhiteSpace(newPriority))
            {
                return BadRequest("Trạng thái không hợp lệ.");
            }
            try
            {
                await _ticketRepository.UpdatePriority(TicketId, newPriority);
                return Ok(new { message = "Cập nhật thành công" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch("IsFeedBack")]
        public async Task<IActionResult> UpdateIsFeedBack(string TicketId, [FromBody] Boolean newIsFeedBack)
        {
            try
            {
                await _ticketRepository.UpdateIsFeedBack(TicketId, newIsFeedBack);
                return Ok(new { message = "Cập nhật thành công" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchTickets([FromQuery] string? TicketId, [FromQuery] string? title, [FromQuery] int? day, [FromQuery] int? month, [FromQuery] int? year
            ,[FromQuery] int? createdBy, [FromQuery] int? departmentId, [FromQuery] int? assignto)
        {
            try
            {
                var tickets = await _ticketRepository.SearchTickets(TicketId, title, day,month, year, createdBy, departmentId,assignto);

                if (!tickets.Any())
                {
                    return NotFound(new { message = "Không tìm thấy ticket nào phù hợp." });
                }

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ nội bộ.", error = ex.Message });
            }
        }
    }
}
