using Microsoft.EntityFrameworkCore.Migrations;

namespace myRestAPI.Migrations
{
    public partial class ReCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Todos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_CreatorId",
                table: "Todos",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_CreatorId",
                table: "Todos",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_CreatorId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_CreatorId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Todos");
        }
    }
}
