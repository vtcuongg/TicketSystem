using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Data
{
    public class TicketFeedbackAssignee
    {
        [Key]
        public int TicketFeedbackAssigneeID { get; set; }

        [Required] 
        [StringLength(50)]
        public string TicketID { get; set; }

        [Required]  
        public int AssignedTo { get; set; }

        // Quan hệ với Ticket
        [ForeignKey(nameof(TicketID))] 
        public virtual Ticket? Ticket { get; set; }

        // Quan hệ với User (Người được đánh giá)
        [ForeignKey(nameof(AssignedTo))]
        public virtual User? User { get; set; }
    }
}
