using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.DataAccessLayer.Implementation.EntityFramework.Migrations
{
    public partial class AddUsersWards2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wards_UserData_Ward_UserId",
                table: "Users_Wards");

            migrationBuilder.DropIndex(
                name: "IX_Users_Wards_Ward_UserId",
                table: "Users_Wards");

            migrationBuilder.DropColumn(
                name: "Ward_UserId",
                table: "Users_Wards");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Wards_WardUserId",
                table: "Users_Wards",
                column: "WardUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Wards_UserData_WardUserId",
                table: "Users_Wards",
                column: "WardUserId",
                principalTable: "UserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wards_UserData_WardUserId",
                table: "Users_Wards");

            migrationBuilder.DropIndex(
                name: "IX_Users_Wards_WardUserId",
                table: "Users_Wards");

            migrationBuilder.AddColumn<int>(
                name: "Ward_UserId",
                table: "Users_Wards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Wards_Ward_UserId",
                table: "Users_Wards",
                column: "Ward_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Wards_UserData_Ward_UserId",
                table: "Users_Wards",
                column: "Ward_UserId",
                principalTable: "UserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
