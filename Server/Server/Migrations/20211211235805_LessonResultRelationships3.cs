using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class LessonResultRelationships3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonResult_LessonResult_LessonResultId",
                table: "UserLessonResult");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonResult_Users_AppUserId",
                table: "UserLessonResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLessonResult",
                table: "UserLessonResult");

            migrationBuilder.RenameTable(
                name: "UserLessonResult",
                newName: "UserLessonResults");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessonResult_LessonResultId",
                table: "UserLessonResults",
                newName: "IX_UserLessonResults_LessonResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLessonResults",
                table: "UserLessonResults",
                columns: new[] { "AppUserId", "LessonResultId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonResults_LessonResult_LessonResultId",
                table: "UserLessonResults",
                column: "LessonResultId",
                principalTable: "LessonResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonResults_Users_AppUserId",
                table: "UserLessonResults",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonResults_LessonResult_LessonResultId",
                table: "UserLessonResults");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonResults_Users_AppUserId",
                table: "UserLessonResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLessonResults",
                table: "UserLessonResults");

            migrationBuilder.RenameTable(
                name: "UserLessonResults",
                newName: "UserLessonResult");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessonResults_LessonResultId",
                table: "UserLessonResult",
                newName: "IX_UserLessonResult_LessonResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLessonResult",
                table: "UserLessonResult",
                columns: new[] { "AppUserId", "LessonResultId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonResult_LessonResult_LessonResultId",
                table: "UserLessonResult",
                column: "LessonResultId",
                principalTable: "LessonResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonResult_Users_AppUserId",
                table: "UserLessonResult",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
