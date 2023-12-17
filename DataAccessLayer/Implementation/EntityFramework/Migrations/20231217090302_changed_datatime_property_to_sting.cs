using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.DataAccessLayer.Implementation.EntityFramework.Migrations
{
    public partial class changed_datatime_property_to_sting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "AnalysisResults");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "AnalysisResults",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "AnalysisResults");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "AnalysisResults",
                type: "datetime2",
                nullable: true);
        }
    }
}
