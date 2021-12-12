using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class LessonResultRelationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Fullname");

            migrationBuilder.CreateTable(
                name: "LessonResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CorrectWord = table.Column<int>(type: "INTEGER", nullable: false),
                    NotCorrectWord = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonLessonResults",
                columns: table => new
                {
                    LessonResultId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonLessonResults", x => new { x.LessonResultId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_LessonLessonResults_LessonResult_LessonResultId",
                        column: x => x.LessonResultId,
                        principalTable: "LessonResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonLessonResults_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLessonResult",
                columns: table => new
                {
                    LessonResultId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLessonResult", x => new { x.AppUserId, x.LessonResultId });
                    table.ForeignKey(
                        name: "FK_UserLessonResult_LessonResult_LessonResultId",
                        column: x => x.LessonResultId,
                        principalTable: "LessonResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLessonResult_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonLessonResults_LessonId",
                table: "LessonLessonResults",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonResult_LessonResultId",
                table: "UserLessonResult",
                column: "LessonResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonLessonResults");

            migrationBuilder.DropTable(
                name: "UserLessonResult");

            migrationBuilder.DropTable(
                name: "LessonResult");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Users",
                newName: "FullName");
        }
    }
}
