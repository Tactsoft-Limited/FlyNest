using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCountryTableTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "Country");

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 443, DateTimeKind.Unspecified).AddTicks(5835), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 443, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 443, DateTimeKind.Unspecified).AddTicks(5883), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 443, DateTimeKind.Unspecified).AddTicks(5885), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(193), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(227), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(230), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(233), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(235), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(238), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(243), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(245), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 444, DateTimeKind.Unspecified).AddTicks(248), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 465, DateTimeKind.Unspecified).AddTicks(2738), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 465, DateTimeKind.Unspecified).AddTicks(2781), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 465, DateTimeKind.Unspecified).AddTicks(2787), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 465, DateTimeKind.Unspecified).AddTicks(2791), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 465, DateTimeKind.Unspecified).AddTicks(2796), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 23, 10, 0, 465, DateTimeKind.Unspecified).AddTicks(2799), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 17, 10, 0, 485, DateTimeKind.Unspecified).AddTicks(4321), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 17, 10, 0, 485, DateTimeKind.Unspecified).AddTicks(4325), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 17, 10, 0, 485, DateTimeKind.Unspecified).AddTicks(4327), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 17, 10, 0, 485, DateTimeKind.Unspecified).AddTicks(4329), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 17, 10, 0, 485, DateTimeKind.Unspecified).AddTicks(4332), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExchangeRate",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 556, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 556, DateTimeKind.Unspecified).AddTicks(6410), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 556, DateTimeKind.Unspecified).AddTicks(6412), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 556, DateTimeKind.Unspecified).AddTicks(6414), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(800), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(802), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(805), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(807), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(809), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(811), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(813), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(815), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 557, DateTimeKind.Unspecified).AddTicks(817), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 576, DateTimeKind.Unspecified).AddTicks(9525), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 576, DateTimeKind.Unspecified).AddTicks(9575), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 576, DateTimeKind.Unspecified).AddTicks(9579), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 576, DateTimeKind.Unspecified).AddTicks(9586), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 576, DateTimeKind.Unspecified).AddTicks(9589), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 16, 32, 18, 576, DateTimeKind.Unspecified).AddTicks(9592), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6111), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6115), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6117), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6122), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
