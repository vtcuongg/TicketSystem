using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Data
{
    public class MyDbContext : DbContext 
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketFeedBack> TicketFeedBacks { get; set; }
        public DbSet<TicketFeedbackAssignee> TicketFeedbackAssignees { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasIndex(r => r.RoleName).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(d => d.DepartmentName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.NationalID).IsUnique();

            modelBuilder.Entity<TicketFeedbackAssignee>()
                .HasKey(tfa => new { tfa.FeedbackID, tfa.AssignedTo });

            modelBuilder.Entity<TicketFeedBack>()
           .HasOne(tf => tf.User)
           .WithMany()
           .HasForeignKey(tf => tf.CreatedBy)
           .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TicketFeedbackAssignee>()
                .HasOne(tfa => tfa.User)
                .WithMany()
                .HasForeignKey(tfa => tfa.AssignedTo)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
           .Property(u => u.CreatedAt)
           .HasDefaultValueSql("SYSDATETIME()");

            modelBuilder.Entity<User>()
           .ToTable(t => t.HasCheckConstraint("CK_User_Gender", "Gender IN (N'Nam', N'Nữ', N'Khác')"));
            modelBuilder.Entity<User>()
            .ToTable(tb => tb.HasCheckConstraint("CHK_User_Status", "Status IN (N'Active', N'Inactive')")); 

            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ticket>()
           .ToTable(tb => tb.HasCheckConstraint("CHK_Ticket_Priority", "Priority IN (N'Thấp', N'Trung bình', N'Cao', N'Khẩn cấp')"));

            // ✅ Ràng buộc CHECK cho Status
            modelBuilder.Entity<Ticket>()
                .ToTable(tb => tb.HasCheckConstraint("CHK_Ticket_Status", "Status IN (N'Mới', N'Đang xử lý', N'Chờ xác nhận', N'Hoàn thành', N'Đã hủy',N'Cháy Deadline')"));

            modelBuilder.Entity<Category>()
            .HasOne(c => c.Department)
            .WithMany()
            .HasForeignKey(c => c.DepartmentID)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
