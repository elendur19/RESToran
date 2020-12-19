using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RESToran.Migrations
{
    public partial class dish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HoursOpened",
                table: "Restaurants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Restaurants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DishId",
                table: "ReservationPeriod",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RestaurantId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    HouseSpecial = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dish_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPeriod_DishId",
                table: "ReservationPeriod",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_RestaurantId",
                table: "Dish",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationPeriod_Dish_DishId",
                table: "ReservationPeriod",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationPeriod_Dish_DishId",
                table: "ReservationPeriod");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_ReservationPeriod_DishId",
                table: "ReservationPeriod");

            migrationBuilder.DropColumn(
                name: "HoursOpened",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "ReservationPeriod");
        }
    }
}
