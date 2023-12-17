using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.DataAccessLayer.Implementation.EntityFramework.Migrations
{
    public partial class AddedIcons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconURL",
                table: "UserData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconURL",
                table: "UserData");
        }
    }
}
