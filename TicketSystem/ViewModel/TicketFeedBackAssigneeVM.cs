using System.ComponentModel.DataAnnotations;

namespace TicketSystem.ViewModel
{
    public class TicketFeedBackAssigneeVM
    {
        public int FeedbackID { get; set; }
        public int AssignedTo { get; set; }
    }
}
