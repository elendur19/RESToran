using Microsoft.EntityFrameworkCore.Migrations;

namespace RESToran.Migrations
{
    public partial class TableRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Table",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Table",
                newName: "Location");
        }
    }
}
