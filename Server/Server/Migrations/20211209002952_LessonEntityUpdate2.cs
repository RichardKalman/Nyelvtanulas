using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class LessonEntityUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonWords_Lessons_LessonsId",
                table: "LessonWords");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonWords_Words_WordsId",
                table: "LessonWords");

            migrationBuilder.RenameColumn(
                name: "WordsId",
                table: "LessonWords",
                newName: "WordId");

            migrationBuilder.RenameColumn(
                name: "LessonsId",
                table: "LessonWords",
                newName: "LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonWords_WordsId",
                table: "LessonWords",
                newName: "IX_LessonWords_WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonWords_Lessons_LessonId",
                table: "LessonWords",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonWords_Words_WordId",
                table: "LessonWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonWords_Lessons_LessonId",
                table: "LessonWords");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonWords_Words_WordId",
                table: "LessonWords");

            migrationBuilder.RenameColumn(
                name: "WordId",
                table: "LessonWords",
                newName: "WordsId");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "LessonWords",
                newName: "LessonsId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonWords_WordId",
                table: "LessonWords",
                newName: "IX_LessonWords_WordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonWords_Lessons_LessonsId",
                table: "LessonWords",
                column: "LessonsId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonWords_Words_WordsId",
                table: "LessonWords",
                column: "WordsId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
