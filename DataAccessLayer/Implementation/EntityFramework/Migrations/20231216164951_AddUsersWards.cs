using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.DataAccessLayer.Implementation.EntityFramework.Migrations
{
    public partial class AddUsersWards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users_Wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WardUserId = table.Column<int>(type: "int", nullable: false),
                    Ward_UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Wards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Wards_UserData_UserId",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Users_Wards_UserData_Ward_UserId",
                        column: x => x.Ward_UserId,
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Wards_UserId",
                table: "Users_Wards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Wards_Ward_UserId",
                table: "Users_Wards",
                column: "Ward_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_Wards");
        }
    }
}
