using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGenderUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Gender",
                table: "Users");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Gender",
                table: "Users",
                sql: "Gender IN (N'Nam', N'Nữ', N'Khác')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Gender",
                table: "Users");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Gender",
                table: "Users",
                sql: "Gender IN ('Nam', 'Nữ', 'Khác')");
        }
    }
}
