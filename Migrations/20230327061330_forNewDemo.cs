using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosteringPractice.Migrations
{
    public partial class forNewDemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.Id);
                });

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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInfo_UserSkills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "UserSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Angular" },
                    { 3, "Web API" },
                    { 4, "Python" },
                    { 5, "Java" },
                    { 6, "Machine Learning" }
                });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "Email", "Gender", "Location", "Name", "Password", "Position", "SkillId" },
                values: new object[] { 1, "Vishalanilrathod@gmail.com", "Male", "Vadodara", "Vishal Rathod", "Vishal@123", "Developer Trainee", 1 });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "Email", "Gender", "Location", "Name", "Password", "Position", "SkillId" },
                values: new object[] { 2, "rahulparik12@gmail.com", "Male", "Vadodara", "Rahul Parik", "Vishal@123", "Seniour Developer Trainee", 2 });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "Email", "Gender", "Location", "Name", "Password", "Position", "SkillId" },
                values: new object[] { 3, "sdrathod4801@gmail.com", "Male", "Banglore", "Shubham Rathod", "Vishal@123", "Jr. Software Trainee", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_SkillId",
                table: "UsersInfo",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersInfo");

            migrationBuilder.DropTable(
                name: "UserSkills");
        }
    }
}
