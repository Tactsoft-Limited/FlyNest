using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFlightHotelReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Child",
                table: "HotelReservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ToDate",
                table: "FlightReservation",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "Infants",
                table: "FlightReservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Child",
                table: "FlightReservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(762), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(1153), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(1155), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(1158), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8468), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8500), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8503), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8505), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8507), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8509), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8511), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8513), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8515), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 689, DateTimeKind.Unspecified).AddTicks(8518), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 693, DateTimeKind.Unspecified).AddTicks(9731), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 693, DateTimeKind.Unspecified).AddTicks(9779), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 693, DateTimeKind.Unspecified).AddTicks(9811), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 693, DateTimeKind.Unspecified).AddTicks(9814), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 693, DateTimeKind.Unspecified).AddTicks(9818), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 2, 34, 693, DateTimeKind.Unspecified).AddTicks(9822), new TimeSpan(0, 6, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Child",
                table: "HotelReservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ToDate",
                table: "FlightReservation",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Infants",
                table: "FlightReservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Child",
                table: "FlightReservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(1762), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(1802), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(1803), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(1805), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5633), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5678), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5682), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5685), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5687), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5689), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 64, DateTimeKind.Unspecified).AddTicks(5691), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 68, DateTimeKind.Unspecified).AddTicks(3684), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 68, DateTimeKind.Unspecified).AddTicks(3721), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 68, DateTimeKind.Unspecified).AddTicks(3725), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 68, DateTimeKind.Unspecified).AddTicks(3728), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 68, DateTimeKind.Unspecified).AddTicks(3732), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 16, 7, 46, 68, DateTimeKind.Unspecified).AddTicks(3735), new TimeSpan(0, 6, 0, 0, 0)));
        }
    }
}
