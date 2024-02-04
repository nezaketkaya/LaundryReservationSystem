using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaundryReservationSystem.Migrations
{
    public partial class initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingTime",
                table: "UserBooking",
                newName: "BookingTimeStart");

            migrationBuilder.RenameColumn(
                name: "BookingTime",
                table: "Bookings",
                newName: "BookingTimeStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingTimeFinish",
                table: "UserBooking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingTimeFinish",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingTimeFinish",
                table: "UserBooking");

            migrationBuilder.DropColumn(
                name: "BookingTimeFinish",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "BookingTimeStart",
                table: "UserBooking",
                newName: "BookingTime");

            migrationBuilder.RenameColumn(
                name: "BookingTimeStart",
                table: "Bookings",
                newName: "BookingTime");
        }
    }
}
