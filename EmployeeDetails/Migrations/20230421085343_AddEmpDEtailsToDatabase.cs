using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDetails.Migrations
{
    /// <inheritdoc />
    public partial class AddEmpDEtailsToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Details",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Details",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Details");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Details",
                newName: "FullName");
        }
    }
}
