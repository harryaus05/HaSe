using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaSe.Soft.Migrations
{
    /// <inheritdoc />
    public partial class newclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "Project",
                table: "PartSpecificationStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Project",
                table: "PartSpecificationStatus");
        }
    }
}
