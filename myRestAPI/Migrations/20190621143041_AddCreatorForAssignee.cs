using Microsoft.EntityFrameworkCore.Migrations;

namespace myRestAPI.Migrations
{
    public partial class AddCreatorForAssignee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Assignees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_CreatorId",
                table: "Assignees",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Users_CreatorId",
                table: "Assignees",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Users_CreatorId",
                table: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_CreatorId",
                table: "Assignees");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Assignees");
        }
    }
}
