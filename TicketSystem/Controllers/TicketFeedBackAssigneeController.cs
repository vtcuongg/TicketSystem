using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Repositories.Interface;
using TicketSystem.ViewModel;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketFeedBackAssigneeController : ControllerBase
    {
        private readonly ITicketFeedBackAssigneeRepository _ticketFeedBackAssigneeRepository;
        public TicketFeedBackAssigneeController(ITicketFeedBackAssigneeRepository ticketFeedBackAssigneeRepository)
        {
            this._ticketFeedBackAssigneeRepository = ticketFeedBackAssigneeRepository;
        }
      
        [HttpPost]
        public async Task<IActionResult> AddTicketFeedBackAssignee(TicketFeedBackAssigneeVM ticketFeedBackAssignee)
        {
            
                await _ticketFeedBackAssigneeRepository.Add(ticketFeedBackAssignee);
                return Ok(new { message = "Success" });
            
                
           
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int feedbackId, int assignedTo)
        {
            await _ticketFeedBackAssigneeRepository.Delete(feedbackId, assignedTo);
            return Ok(new { message = "Success" });
        }
    }
}
