using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestRelationsHelper.Data.Migrations
{
    public partial class GuestEntiyAdde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_AspNetUsers_UserId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Reservations_ReservationId1",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_ReservationId1",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_UserId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId1",
                table: "Guests");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Guests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId1",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ReservationId1",
                table: "Guests",
                column: "ReservationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_UserId",
                table: "Guests",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_AspNetUsers_UserId",
                table: "Guests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Reservations_ReservationId1",
                table: "Guests",
                column: "ReservationId1",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
