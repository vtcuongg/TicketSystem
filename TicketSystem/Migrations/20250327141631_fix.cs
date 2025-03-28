using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketFeedbackAssignees_TicketFeedbBacks_FeedbackID",
                table: "TicketFeedbackAssignees");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFeedbBacks_Tickets_TicketID",
                table: "TicketFeedbBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFeedbBacks_Users_CreatedBy",
                table: "TicketFeedbBacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketFeedbBacks",
                table: "TicketFeedbBacks");

            migrationBuilder.RenameTable(
                name: "TicketFeedbBacks",
                newName: "TicketFeedBacks");

            migrationBuilder.RenameIndex(
                name: "IX_TicketFeedbBacks_TicketID",
                table: "TicketFeedBacks",
                newName: "IX_TicketFeedBacks_TicketID");

            migrationBuilder.RenameIndex(
                name: "IX_TicketFeedbBacks_CreatedBy",
                table: "TicketFeedBacks",
                newName: "IX_TicketFeedBacks_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketFeedBacks",
                table: "TicketFeedBacks",
                column: "FeedbackID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFeedbackAssignees_TicketFeedBacks_FeedbackID",
                table: "TicketFeedbackAssignees",
                column: "FeedbackID",
                principalTable: "TicketFeedBacks",
                principalColumn: "FeedbackID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFeedBacks_Tickets_TicketID",
                table: "TicketFeedBacks",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFeedBacks_Users_CreatedBy",
                table: "TicketFeedBacks",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketFeedbackAssignees_TicketFeedBacks_FeedbackID",
                table: "TicketFeedbackAssignees");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFeedBacks_Tickets_TicketID",
                table: "TicketFeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFeedBacks_Users_CreatedBy",
                table: "TicketFeedBacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketFeedBacks",
                table: "TicketFeedBacks");

            migrationBuilder.RenameTable(
                name: "TicketFeedBacks",
                newName: "TicketFeedbBacks");

            migrationBuilder.RenameIndex(
                name: "IX_TicketFeedBacks_TicketID",
                table: "TicketFeedbBacks",
                newName: "IX_TicketFeedbBacks_TicketID");

            migrationBuilder.RenameIndex(
                name: "IX_TicketFeedBacks_CreatedBy",
                table: "TicketFeedbBacks",
                newName: "IX_TicketFeedbBacks_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketFeedbBacks",
                table: "TicketFeedbBacks",
                column: "FeedbackID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFeedbackAssignees_TicketFeedbBacks_FeedbackID",
                table: "TicketFeedbackAssignees",
                column: "FeedbackID",
                principalTable: "TicketFeedbBacks",
                principalColumn: "FeedbackID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFeedbBacks_Tickets_TicketID",
                table: "TicketFeedbBacks",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFeedbBacks_Users_CreatedBy",
                table: "TicketFeedbBacks",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
