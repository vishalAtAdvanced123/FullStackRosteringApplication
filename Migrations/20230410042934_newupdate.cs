using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosteringPractice.Migrations
{
    public partial class newupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DesignationList",
                keyColumn: "Id",
                keyValue: 3,
                column: "DesignationName",
                value: "Senior Software Developer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DesignationList",
                keyColumn: "Id",
                keyValue: 3,
                column: "DesignationName",
                value: "Seniour Software Developer");
        }
    }
}
