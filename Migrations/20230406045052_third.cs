using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosteringPractice.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_UserName",
                table: "UsersInfo");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UsersInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_UserName",
                table: "UsersInfo",
                column: "UserName",
                unique: true);
        }
    }
}
