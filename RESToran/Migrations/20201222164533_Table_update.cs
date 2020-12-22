using Microsoft.EntityFrameworkCore.Migrations;

namespace RESToran.Migrations
{
    public partial class Table_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Table_TableNumber",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Table");

            migrationBuilder.AddColumn<string>(
                name: "RestName_Number",
                table: "Table",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_RestName_Number",
                table: "Table",
                column: "RestName_Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Table_RestName_Number",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "RestName_Number",
                table: "Table");

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Table",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Table_TableNumber",
                table: "Table",
                column: "TableNumber",
                unique: true);
        }
    }
}
