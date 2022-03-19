using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_BerrrasBio.Migrations
{
    public partial class inti4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowtimeID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "showsId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_showsId",
                table: "Booking",
                column: "showsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Show_showsId",
                table: "Booking",
                column: "showsId",
                principalTable: "Show",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Show_showsId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_showsId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ShowtimeID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "showsId",
                table: "Booking");
        }
    }
}
