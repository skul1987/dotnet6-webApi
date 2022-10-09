using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class UserEmployeeRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "updatedbyUserid",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_updatedbyUserid",
                table: "Employees",
                column: "updatedbyUserid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_updatedbyUserid",
                table: "Employees",
                column: "updatedbyUserid",
                principalTable: "Users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_updatedbyUserid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_updatedbyUserid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "updatedbyUserid",
                table: "Employees");
        }
    }
}
