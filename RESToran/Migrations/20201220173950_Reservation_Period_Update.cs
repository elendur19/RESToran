using Microsoft.EntityFrameworkCore.Migrations;

namespace RESToran.Migrations
{
    public partial class Reservation_Period_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startTime",
                table: "ReservationPeriod",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "endTime",
                table: "ReservationPeriod",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "ReservationPeriod",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "ReservationPeriod",
                newName: "startTime");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "ReservationPeriod",
                newName: "endTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ReservationPeriod",
                newName: "Datum");
        }
    }
}
