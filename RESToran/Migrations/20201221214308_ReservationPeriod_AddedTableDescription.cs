using Microsoft.EntityFrameworkCore.Migrations;

namespace RESToran.Migrations
{
    public partial class ReservationPeriod_AddedTableDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TableDescription",
                table: "ReservationPeriod",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableDescription",
                table: "ReservationPeriod");
        }
    }
}
