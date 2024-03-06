using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaundryReservationSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBooking");

            migrationBuilder.DropColumn(
                name: "BookingTimeFinish",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "UserSurname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "BookingTimeStart",
                table: "Bookings",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "UserSurname",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminCode",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminSurame",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserSurname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserSurname",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AdminCode",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "AdminSurame",
                table: "Admins");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingTimeStart",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingTimeFinish",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "UserBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingTimeFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineNumber = table.Column<int>(type: "int", nullable: false),
                    MachineType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooking", x => x.Id);
                });
        }
    }
}
