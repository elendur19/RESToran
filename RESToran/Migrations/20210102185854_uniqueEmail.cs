using Microsoft.EntityFrameworkCore.Migrations;

namespace RESToran.Migrations
{
    public partial class uniqueEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_EmailAddress",
                table: "Restaurant",
                column: "EmailAddress",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Restaurant_EmailAddress",
                table: "Restaurant");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Restaurant",
                newName: "EmailAdress");
        }
    }
}
