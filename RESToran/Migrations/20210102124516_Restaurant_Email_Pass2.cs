using Microsoft.EntityFrameworkCore.Migrations;

namespace RESToran.Migrations
{
    public partial class Restaurant_Email_Pass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "EmailAddress",
               table: "Restaurant",
               type: "text",
               nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Restaurant",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }


    }
}
