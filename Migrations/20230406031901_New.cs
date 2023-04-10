using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosteringPractice.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesignationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInfo_DesignationList_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "DesignationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInfo_GenderList_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInfo_LocationList_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkills_SkillList_SkillId",
                        column: x => x.SkillId,
                        principalTable: "SkillList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkills_UsersInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DesignationList",
                columns: new[] { "Id", "DesignationName" },
                values: new object[,]
                {
                    { 1, "Trainee" },
                    { 2, "Jr. Software Developer" },
                    { 3, "Seniour Software Developer" }
                });

            migrationBuilder.InsertData(
                table: "GenderList",
                columns: new[] { "Id", "GenderName" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "LocationList",
                columns: new[] { "Id", "LocationName" },
                values: new object[,]
                {
                    { 1, "Banglore" },
                    { 2, "Vadodara" },
                    { 3, "Ahamadabad" }
                });

            migrationBuilder.InsertData(
                table: "SkillList",
                columns: new[] { "Id", "SkillName" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Angular" },
                    { 3, "Java" },
                    { 4, "Python" },
                    { 5, "Machine Learning" },
                    { 6, "Web API" },
                    { 7, ".NET" }
                });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "DesignationId", "Email", "FirstName", "GenderId", "LastName", "LocationId", "Password", "UserName" },
                values: new object[] { 1, 1, "Vishalanilrathod@gmail.com", "Vishal", 1, "Rathod", 1, "Vishal@123", "vishal.rathod123" });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "DesignationId", "Email", "FirstName", "GenderId", "LastName", "LocationId", "Password", "UserName" },
                values: new object[] { 2, 2, "rahulparikh12@gmail.com", "Rahul", 1, "Parikh", 2, "Rahul@123", "rahul.rparikh123" });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "DesignationId", "Email", "FirstName", "GenderId", "LastName", "LocationId", "Password", "UserName" },
                values: new object[] { 3, 2, "kirangaudapatil@gmail.com", "Kiran", 1, "Patil", 3, "Kiran@123", "Kiran.patil321" });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id", "SkillId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 1 },
                    { 4, 3, 2 },
                    { 5, 4, 3 },
                    { 6, 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_DesignationId",
                table: "UsersInfo",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_GenderId",
                table: "UsersInfo",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_LocationId",
                table: "UsersInfo",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_UserName",
                table: "UsersInfo",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                column: "SkillId");

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
                name: "SkillList");

            migrationBuilder.DropTable(
                name: "UsersInfo");

            migrationBuilder.DropTable(
                name: "DesignationList");

            migrationBuilder.DropTable(
                name: "GenderList");

            migrationBuilder.DropTable(
                name: "LocationList");
        }
    }
}
