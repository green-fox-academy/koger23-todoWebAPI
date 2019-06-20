using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myRestAPI.Migrations
{
    public partial class CreateBasicUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Assignees_assigneeid",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Todos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "done",
                table: "Todos",
                newName: "Done");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Todos",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "assigneeid",
                table: "Todos",
                newName: "AssigneeId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Todos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_assigneeid",
                table: "Todos",
                newName: "IX_Todos_AssigneeId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Assignees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Assignees",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Assignees",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Assignees_AssigneeId",
                table: "Todos",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Assignees_AssigneeId",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Todos",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "Todos",
                newName: "done");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Todos",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "AssigneeId",
                table: "Todos",
                newName: "assigneeid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Todos",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_AssigneeId",
                table: "Todos",
                newName: "IX_Todos_assigneeid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Assignees",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Assignees",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Assignees",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Assignees_assigneeid",
                table: "Todos",
                column: "assigneeid",
                principalTable: "Assignees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
