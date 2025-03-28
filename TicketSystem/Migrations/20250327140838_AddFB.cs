using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddFB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeedBack",
                table: "Tickets",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketFeedbBacks",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketFeedbBacks", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK_TicketFeedbBacks_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketFeedbBacks_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "TicketFeedbackAssignees",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketFeedbackAssignees", x => new { x.FeedbackID, x.AssignedTo });
                    table.ForeignKey(
                        name: "FK_TicketFeedbackAssignees_TicketFeedbBacks_FeedbackID",
                        column: x => x.FeedbackID,
                        principalTable: "TicketFeedbBacks",
                        principalColumn: "FeedbackID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketFeedbackAssignees_Users_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketFeedbackAssignees_AssignedTo",
                table: "TicketFeedbackAssignees",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFeedbBacks_CreatedBy",
                table: "TicketFeedbBacks",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFeedbBacks_TicketID",
                table: "TicketFeedbBacks",
                column: "TicketID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketFeedbackAssignees");

            migrationBuilder.DropTable(
                name: "TicketFeedbBacks");

            migrationBuilder.DropColumn(
                name: "IsFeedBack",
                table: "Tickets");
        }
    }
}
