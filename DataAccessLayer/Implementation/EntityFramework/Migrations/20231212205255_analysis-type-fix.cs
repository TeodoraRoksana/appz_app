using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.DataAccessLayer.Implementation.EntityFramework.Migrations
{
    public partial class analysistypefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_fieldsData",
                table: "AnalysisTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_fieldsData",
                table: "AnalysisTypes");
        }
    }
}
