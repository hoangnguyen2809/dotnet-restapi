using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    courseCode = table.Column<string>(type: "TEXT", nullable: false),
                    facultyId = table.Column<int>(type: "INTEGER", nullable: false),
                    courseDescription = table.Column<string>(type: "TEXT", nullable: true),
                    credits = table.Column<int>(type: "INTEGER", nullable: false),
                    instructor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Courses_Faculties_facultyId",
                        column: x => x.facultyId,
                        principalTable: "Faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Applied Sciences" },
                    { 2, "Arts and Social Sciences" },
                    { 3, "Education" },
                    { 4, "Business" },
                    { 5, "Communication, Art and Technology" },
                    { 6, "Environment" },
                    { 7, "Health Sciences" },
                    { 8, "Science" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_facultyId",
                table: "Courses",
                column: "facultyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
