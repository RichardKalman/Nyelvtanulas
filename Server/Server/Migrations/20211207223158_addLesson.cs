using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class addLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonWords",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    WordsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonWords", x => new { x.LessonsId, x.WordsId });
                    table.ForeignKey(
                        name: "FK_LessonWords_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonWords_Words_WordsId",
                        column: x => x.WordsId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonWords_WordsId",
                table: "LessonWords",
                column: "WordsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonWords");

            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
