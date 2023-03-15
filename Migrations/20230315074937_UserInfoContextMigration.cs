using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosteringPractice.Migrations
{
    public partial class UserInfoContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "C#" });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Angular" });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Web API" });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Python" });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Java" });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Machine Learning" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Location", "Name", "Password", "SkillId" },
                values: new object[] { 1, "Vishalanilrathod@gmail.com", "Vadodara", "Vishal Rathod", "Vishal@123", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Location", "Name", "Password", "SkillId" },
                values: new object[] { 2, "rahulparik12@gmail.com", "Vadodara", "Rahul Parik", "Rahul@123", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Location", "Name", "Password", "SkillId" },
                values: new object[] { 3, "sdrathod4801@gmail.com", "Vadodara", "Shubham Rathod", "Shubham@123", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SkillId",
                table: "Users",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "skills");
        }
    }
}
