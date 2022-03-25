using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_BerrrasBio.Migrations
{
    public partial class redidmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "PricePerTicket",
                table: "Show",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerTicket",
                table: "Show");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Movie",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
