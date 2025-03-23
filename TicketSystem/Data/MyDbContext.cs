using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Data
{
    public class MyDbContext : DbContext 
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasIndex(r => r.RoleName).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(d => d.DepartmentName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.NationalID).IsUnique();


            modelBuilder.Entity<User>()
           .Property(u => u.CreatedAt)
           .HasDefaultValueSql("SYSDATETIME()");

            modelBuilder.Entity<User>()
           .ToTable(t => t.HasCheckConstraint("CK_User_Gender", "Gender IN (N'Nam', N'Nữ', N'Khác')"));

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

        }
    }
}
