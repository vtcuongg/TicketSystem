namespace TicketSystem.ViewModel
{
    public class AssignmentVM
    {
         public int? AssignmentID { get; set; }
        public int? AssignedTo { get; set; }

        // Thêm thông tin người xử lý
        public string? FullName { get; set; } 
        public string? Avatar { get; set; }
    }
}
