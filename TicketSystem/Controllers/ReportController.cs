using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Repositories.Interface;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository)
        {
            this._reportRepository = reportRepository;
        }
        [HttpGet("RatingReport")]
        public async Task<IActionResult> GetRatingReport(int DepartmentId)
        {
          var ratingReport=   await _reportRepository.GetRatingReport(DepartmentId);
            return Ok(ratingReport);

        }

        [HttpGet("SumaryTicket")]
        public async Task<IActionResult> GetSumaryTicket( int? month , int? year , int DepartmentId)
        {
            var sumaryTicket = await _reportRepository.GetTicketSummary(month,year, DepartmentId);
            return Ok(sumaryTicket);

        }
        [HttpGet("SumaryUser")]
        public async Task<IActionResult> GetSumaryUser(int DepartmentId)
        {
            var sumaryUser = await _reportRepository.GetUserSumary(DepartmentId);
            return Ok(sumaryUser);

        }
    }
}
