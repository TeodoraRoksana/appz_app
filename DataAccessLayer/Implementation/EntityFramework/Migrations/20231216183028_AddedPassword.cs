using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.DataAccessLayer.Implementation.EntityFramework.Migrations
{
    public partial class AddedPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EncryptedPassword",
                table: "UserData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncryptedPassword",
                table: "UserData");
        }
    }
}
