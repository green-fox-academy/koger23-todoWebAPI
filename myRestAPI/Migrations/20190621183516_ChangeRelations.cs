using Microsoft.EntityFrameworkCore.Migrations;

namespace myRestAPI.Migrations
{
    public partial class ChangeRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Users_CreatorId",
                table: "Assignees");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Assignees_AssigneeId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_CreatorId",
                table: "Assignees");

            migrationBuilder.AlterColumn<long>(
                name: "AssigneeId",
                table: "Todos",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Todos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "CreatorId",
                table: "Assignees",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId1",
                table: "Assignees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_CreatorId1",
                table: "Assignees",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Users_CreatorId1",
                table: "Assignees",
                column: "CreatorId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Assignees_AssigneeId",
                table: "Todos",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Users_CreatorId1",
                table: "Assignees");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Assignees_AssigneeId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_CreatorId1",
                table: "Assignees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Assignees");

            migrationBuilder.AlterColumn<long>(
                name: "AssigneeId",
                table: "Todos",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Assignees",
                nullable: true,
                oldClrType: typeof(long));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Assignees_AssigneeId",
                table: "Todos",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
