using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVisaRequrementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaxStay",
                table: "VisaRequirement",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "VisaRequirement",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Validity",
                table: "VisaRequirement",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(4956), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(4960), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(4963), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9333), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9354), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9358), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9427), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9430), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9434), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9437), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9440), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9444), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 929, DateTimeKind.Unspecified).AddTicks(9447), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 967, DateTimeKind.Unspecified).AddTicks(9982), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 968, DateTimeKind.Unspecified).AddTicks(39), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 968, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 968, DateTimeKind.Unspecified).AddTicks(50), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 968, DateTimeKind.Unspecified).AddTicks(55), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 3, 14, 14, 51, 43, 968, DateTimeKind.Unspecified).AddTicks(68), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "MaxStay", "Title", "Validity" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 3, 14, 8, 51, 43, 998, DateTimeKind.Unspecified).AddTicks(8343), new TimeSpan(0, 0, 0, 0, 0)), "30 Days", null, "90 Days" });

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "MaxStay", "Title", "Validity" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 3, 14, 8, 51, 43, 998, DateTimeKind.Unspecified).AddTicks(8350), new TimeSpan(0, 0, 0, 0, 0)), "30 Days", null, "90 Days" });

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "MaxStay", "Title", "Validity" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 3, 14, 8, 51, 43, 998, DateTimeKind.Unspecified).AddTicks(8353), new TimeSpan(0, 0, 0, 0, 0)), "30 Days", null, "90 Days" });

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedDate", "MaxStay", "Title", "Validity" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 3, 14, 8, 51, 43, 998, DateTimeKind.Unspecified).AddTicks(8357), new TimeSpan(0, 0, 0, 0, 0)), "30 Days", null, "90 Days" });

            migrationBuilder.UpdateData(
                table: "VisaRequirement",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedDate", "MaxStay", "Title", "Validity" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 3, 14, 8, 51, 43, 998, DateTimeKind.Unspecified).AddTicks(8360), new TimeSpan(0, 0, 0, 0, 0)), "30 Days", null, "90 Days" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxStay",
                table: "VisaRequirement");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "VisaRequirement");

            migrationBuilder.DropColumn(
                name: "Validity",
                table: "VisaRequirement");

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
    }
}
