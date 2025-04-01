using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Data
{
    public class TicketFeedBack
    {
        [Key]
        public int FeedbackID { get; set; }

        [Required]
        public string TicketID { get; set; }

        [Required]
        public int? CreatedBy { get; set; } // Người tạo feedback

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Quan hệ với Ticket
        [ForeignKey("TicketID")]
        public virtual Ticket? Ticket { get; set; }

        // Quan hệ với User (Người tạo feedback)
        [ForeignKey("CreatedBy")]
        public virtual User? User { get; set; }
    }
}
