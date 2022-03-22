using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_BerrrasBio.Migrations
{
    public partial class intit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Movie_MovieId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_MovieId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MovieId",
                table: "Booking",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Movie_MovieId",
                table: "Booking",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
        }
    }
}
