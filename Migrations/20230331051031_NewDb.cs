using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosteringPractice.Migrations
{
    public partial class NewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkills_UsersInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "Email", "Gender", "Location", "Name", "Password", "Position" },
                values: new object[] { 1, "Vishalanilrathod@gmail.com", "Male", "Vadodara", "Vishal Rathod", "Vishal@123", "Developer Trainee" });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "Email", "Gender", "Location", "Name", "Password", "Position" },
                values: new object[] { 2, "rahulparik12@gmail.com", "Male", "Vadodara", "Rahul Parik", "Vishal@123", "Seniour Developer Trainee" });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "Email", "Gender", "Location", "Name", "Password", "Position" },
                values: new object[] { 3, "sdrathod4801@gmail.com", "Male", "Banglore", "Shubham Rathod", "Vishal@123", "Jr. Software Trainee" });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "C#", 1 },
                    { 2, "Angular", 1 },
                    { 3, "Web API", 2 },
                    { 4, "Python", 2 },
                    { 5, "Java", 3 },
                    { 6, "Machine Learning", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UserId",
                table: "UserSkills",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "UsersInfo");
        }
    }
}
