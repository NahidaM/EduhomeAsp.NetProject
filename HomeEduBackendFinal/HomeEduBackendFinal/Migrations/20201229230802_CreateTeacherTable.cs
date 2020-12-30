using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeEduBackendFinal.Migrations
{
    public partial class CreateTeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Pinterest = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    Hobby = table.Column<string>(nullable: true),
                    Faculty = table.Column<string>(nullable: true),
                    Skype = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    VContact = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherUsers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CategoryId",
                table: "Teachers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUsers_TeacherId",
                table: "TeacherUsers",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherUsers");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
