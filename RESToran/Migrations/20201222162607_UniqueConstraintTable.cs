using Microsoft.EntityFrameworkCore.Migrations;

namespace RESToran.Migrations
{
    public partial class UniqueConstraintTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Table_TableNumber",
                table: "Table",
                column: "TableNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Table_TableNumber",
                table: "Table");
        }
    }
}
