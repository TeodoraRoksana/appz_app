using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.DataAccessLayer.Implementation.EntityFramework.Migrations
{
    public partial class Analysis1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AnalysisTypeId",
                table: "AnalysisResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDataId",
                table: "AnalysisResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisResults_AnalysisTypeId",
                table: "AnalysisResults",
                column: "AnalysisTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisResults_UserDataId",
                table: "AnalysisResults",
                column: "UserDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysisResults_AnalysisTypes_AnalysisTypeId",
                table: "AnalysisResults",
                column: "AnalysisTypeId",
                principalTable: "AnalysisTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysisResults_Patients_UserDataId",
                table: "AnalysisResults",
                column: "UserDataId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysisResults_AnalysisTypes_AnalysisTypeId",
                table: "AnalysisResults");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalysisResults_Patients_UserDataId",
                table: "AnalysisResults");

            migrationBuilder.DropIndex(
                name: "IX_AnalysisResults_AnalysisTypeId",
                table: "AnalysisResults");

            migrationBuilder.DropIndex(
                name: "IX_AnalysisResults_UserDataId",
                table: "AnalysisResults");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AnalysisTypeId",
                table: "AnalysisResults");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "AnalysisResults");
        }
    }
}
