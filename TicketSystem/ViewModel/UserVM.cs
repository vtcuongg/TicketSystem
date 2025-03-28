using System.ComponentModel.DataAnnotations;

namespace TicketSystem.ViewModel
{
    public class UserVM
    {

        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [RegularExpression("^0[0-9]{9}$", ErrorMessage = "Phone number must be 10 digits and start with 0.")]

        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        [Required]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "National ID must be exactly 12 digits.")]

        public string? NationalID { get; set; }
        public int? DepartmentID { get; set; }
        public int? RoleID { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
