using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Data
{
    public class User
    {

        [Key]
        public int UserID { get; set; }

        [Required, StringLength(255)]
        public string FullName { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string Email { get; set; } = string.Empty;

         public string? Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(500)]
        public string? Avatar { get; set; }

         public string? NationalID { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Role")]
        public int? RoleID { get; set; }
        public Role? Role { get; set; }

        [StringLength(10)]
        [Column(TypeName = "NVARCHAR(10)")]
        public string Status { get; set; } = "Active";
        public string PasswordHash { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
