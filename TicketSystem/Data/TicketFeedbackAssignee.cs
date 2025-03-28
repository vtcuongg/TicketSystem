using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Data
{
    public class TicketFeedbackAssignee
    {
        [Key]
        public int FeedbackID { get; set; }

        [Key]
        public int AssignedTo { get; set; }

        // Quan hệ với TicketFeedback
        [ForeignKey("FeedbackID")]
        public virtual TicketFeedBack? TicketFeedback { get; set; }

        // Quan hệ với User (Người được đánh giá)
        [ForeignKey("AssignedTo")]
        public virtual User? User { get; set; }
    }
}
