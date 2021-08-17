using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestRelationsHelper.Data.Migrations
{
    public partial class someValidationAddedForGuestReqeust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestRequests_HotelServices_HotelServiceId",
                table: "GuestRequests");

            migrationBuilder.AlterColumn<string>(
                name: "PnoneNumber",
                table: "Guests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "GuestRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HotelServiceId",
                table: "GuestRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRequests_HotelServices_HotelServiceId",
                table: "GuestRequests",
                column: "HotelServiceId",
                principalTable: "HotelServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestRequests_HotelServices_HotelServiceId",
                table: "GuestRequests");

            migrationBuilder.AlterColumn<string>(
                name: "PnoneNumber",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "GuestRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelServiceId",
                table: "GuestRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRequests_HotelServices_HotelServiceId",
                table: "GuestRequests",
                column: "HotelServiceId",
                principalTable: "HotelServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
