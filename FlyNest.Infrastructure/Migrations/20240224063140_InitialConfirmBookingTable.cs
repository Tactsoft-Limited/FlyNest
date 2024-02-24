using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialConfirmBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmBooking",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourPackageId = table.Column<long>(type: "bigint", nullable: false),
                    PackagePrice = table.Column<double>(type: "float", nullable: false),
                    PackageTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    TotalPerson = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    ClientEmail = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    ClientPhone = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TramAndCondition = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmBooking_TourPackage_TourPackageId",
                        column: x => x.TourPackageId,
                        principalTable: "TourPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 572, DateTimeKind.Unspecified).AddTicks(9053), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 572, DateTimeKind.Unspecified).AddTicks(9093), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 572, DateTimeKind.Unspecified).AddTicks(9096), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 572, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(2998), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(3015), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(3017), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(3019), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(3021), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(3023), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(3025), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(3027), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 573, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 591, DateTimeKind.Unspecified).AddTicks(5338), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 591, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 591, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 591, DateTimeKind.Unspecified).AddTicks(5393), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 591, DateTimeKind.Unspecified).AddTicks(5396), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 24, 12, 31, 37, 591, DateTimeKind.Unspecified).AddTicks(5400), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmBooking_TourPackageId",
                table: "ConfirmBooking",
                column: "TourPackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmBooking");

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(5130), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airline",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(5181), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8932), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8935), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8937), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8938), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8944), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8946), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Airport",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 934, DateTimeKind.Unspecified).AddTicks(8948), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 943, DateTimeKind.Unspecified).AddTicks(3678), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 943, DateTimeKind.Unspecified).AddTicks(3724), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 943, DateTimeKind.Unspecified).AddTicks(3728), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 943, DateTimeKind.Unspecified).AddTicks(3732), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 943, DateTimeKind.Unspecified).AddTicks(3735), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 16, 4, 27, 943, DateTimeKind.Unspecified).AddTicks(3740), new TimeSpan(0, 6, 0, 0, 0)));
        }
    }
}
