using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Departments_DepartmentID",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Category_CategoryID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Departments_DepartmentID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Users_CreatedBy",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_Ticket_Status",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_DepartmentID",
                table: "Tickets",
                newName: "IX_Tickets_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_CreatedBy",
                table: "Tickets",
                newName: "IX_Tickets_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_CategoryID",
                table: "Tickets",
                newName: "IX_Tickets_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Category_DepartmentID",
                table: "Categories",
                newName: "IX_Categories_DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryID");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Ticket_Status",
                table: "Tickets",
                sql: "Status IN (N'Mới', N'Đang xử lý', N'Chờ xác nhận', N'Hoàn thành', N'Đã hủy',N'Cháy Deadline')");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Departments_DepartmentID",
                table: "Categories",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Categories_CategoryID",
                table: "Tickets",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Departments_DepartmentID",
                table: "Tickets",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Departments_DepartmentID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Categories_CategoryID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Departments_DepartmentID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_Ticket_Status",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_DepartmentID",
                table: "Ticket",
                newName: "IX_Ticket_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CreatedBy",
                table: "Ticket",
                newName: "IX_Ticket_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CategoryID",
                table: "Ticket",
                newName: "IX_Ticket_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_DepartmentID",
                table: "Category",
                newName: "IX_Category_DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryID");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Ticket_Status",
                table: "Ticket",
                sql: "Status IN (N'Mới', N'Đang xử lý', N'Chờ xác nhận', N'Hoàn thành', N'Đã hủy')");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Departments_DepartmentID",
                table: "Category",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Category_CategoryID",
                table: "Ticket",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Departments_DepartmentID",
                table: "Ticket",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Users_CreatedBy",
                table: "Ticket",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
