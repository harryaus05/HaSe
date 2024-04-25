using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaSe.Soft.Migrations
{
    /// <inheritdoc />
    public partial class Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Contoso");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Student",
                newSchema: "Contoso");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructor",
                newSchema: "Contoso");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Department",
                newSchema: "Contoso");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Courses",
                newSchema: "Contoso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Student",
                schema: "Contoso",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Instructor",
                schema: "Contoso",
                newName: "Instructor");

            migrationBuilder.RenameTable(
                name: "Department",
                schema: "Contoso",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "Contoso",
                newName: "Courses");
        }
    }
}
