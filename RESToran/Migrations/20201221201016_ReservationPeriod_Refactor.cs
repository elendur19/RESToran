using Microsoft.EntityFrameworkCore.Migrations;

namespace RESToran.Migrations
{
    public partial class ReservationPeriod_Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RestaurantId",
                table: "ReservationPeriod",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "ReservationPeriod");
        }
    }
}
