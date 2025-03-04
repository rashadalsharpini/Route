using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF03.Migrations
{
    /// <inheritdoc />
    public partial class compo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInstructors",
                table: "CourseInstructors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInstructors",
                table: "CourseInstructors",
                columns: new[] { "CourseId", "InstructorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructors_InstructorId",
                table: "CourseInstructors",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructors_Courses_CourseId",
                table: "CourseInstructors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructors_Instructors_InstructorId",
                table: "CourseInstructors",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructors_Courses_CourseId",
                table: "CourseInstructors");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructors_Instructors_InstructorId",
                table: "CourseInstructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInstructors",
                table: "CourseInstructors");

            migrationBuilder.DropIndex(
                name: "IX_CourseInstructors_InstructorId",
                table: "CourseInstructors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInstructors",
                table: "CourseInstructors",
                columns: new[] { "InstructorId", "CourseId" });
        }
    }
}
