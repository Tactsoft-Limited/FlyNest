using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldHotelFlightReservitionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "HotelReservation",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "FlightReservation",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 610, DateTimeKind.Unspecified).AddTicks(657), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 610, DateTimeKind.Unspecified).AddTicks(1187), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 610, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 610, DateTimeKind.Unspecified).AddTicks(1205), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3553), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3587), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3590), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3592), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3598), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3603), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3606), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 611, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 616, DateTimeKind.Unspecified).AddTicks(8316), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 616, DateTimeKind.Unspecified).AddTicks(8365), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 616, DateTimeKind.Unspecified).AddTicks(8369), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 616, DateTimeKind.Unspecified).AddTicks(8373), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 616, DateTimeKind.Unspecified).AddTicks(8376), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 14, 32, 14, 616, DateTimeKind.Unspecified).AddTicks(8380), new TimeSpan(0, 6, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "HotelReservation");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FlightReservation");

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
    }
}
