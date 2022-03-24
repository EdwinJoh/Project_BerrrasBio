using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_BerrrasBio.Migrations
{
    public partial class intit6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Show",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Show");
        }
    }
}
