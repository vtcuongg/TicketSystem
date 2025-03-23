namespace TicketSystem.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string? NationalID { get; set; }
        public int? DepartmentID { get; set; }
        public int? RoleID { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
