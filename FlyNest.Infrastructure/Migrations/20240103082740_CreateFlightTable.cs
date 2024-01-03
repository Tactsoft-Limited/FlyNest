using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateFlightTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineId = table.Column<long>(type: "bigint", nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ArrivalAirportCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AvailableSeats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSeats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AircraftType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoppieId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Stoppies_StoppieId",
                        column: x => x.StoppieId,
                        principalTable: "Stoppies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineId",
                table: "Flight",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_StoppieId",
                table: "Flight",
                column: "StoppieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
