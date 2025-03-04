using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class changename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address",
                table: "students",
                newName: "student_address");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "cources",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: " ",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "student_address",
                table: "students",
                newName: "address");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "cources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: " ");
        }
    }
}
