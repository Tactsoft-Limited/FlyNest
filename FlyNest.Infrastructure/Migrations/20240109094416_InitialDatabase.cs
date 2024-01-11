using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlyNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Baggage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightClass = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    LuggageWeight = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baggage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PriceStartFrom = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    LocationMap = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AirlineId = table.Column<long>(type: "bigint", nullable: false),
                    DepatureAirportId = table.Column<long>(type: "bigint", nullable: false),
                    DepatureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DepatureTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ArrivalAirportId = table.Column<long>(type: "bigint", nullable: false),
                    ArrivalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ArrivalTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AircraftType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FlightDuration = table.Column<TimeSpan>(type: "time", maxLength: 30, nullable: false),
                    FlightType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BaggageId = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_Flight_Airport_ArrivalAirportId",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_DepatureAirportId",
                        column: x => x.DepatureAirportId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Baggage_BaggageId",
                        column: x => x.BaggageId,
                        principalTable: "Baggage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelImages_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Facilities = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Benefits = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PriceParNight = table.Column<double>(type: "float", nullable: false),
                    HotelId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stopover",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportId = table.Column<long>(type: "bigint", nullable: false),
                    StopoverDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StopoverTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stopover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stopover_Airport_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stopover_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Airline",
                columns: new[] { "Id", "AirlineName", "ContactInfo", "CreatedBy", "CreatedDate", "EstablishedDate", "IsDelete", "Logo", "ModifiedBy", "ModifiedDate", "UpdateNo", "Website" },
                values: new object[,]
                {
                    { 1L, "Biman Bangladesh Airlines", "Balaka Bhaban Kurmitola, Dhaka, Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(4109), new TimeSpan(0, 6, 0, 0, 0)), new DateOnly(1, 1, 1), false, null, null, null, 0, "http://biman-airlines.com" },
                    { 2L, "US-Bangla Airlines", "77 Sohrawardi Avenue, Baridhara Diplomatic Zone, Dhaka, Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 6, 0, 0, 0)), new DateOnly(1, 1, 1), false, null, null, null, 0, "https://usbair.com" },
                    { 3L, "Novoair", "House-50, Road-11, Block-F, Banani, Dhaka, Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(4151), new TimeSpan(0, 6, 0, 0, 0)), new DateOnly(1, 1, 1), false, null, null, null, 0, "https://www.flynovoair.com" },
                    { 4L, "Regent Airways", "Balaka Bhaban Kurmitola, Dhaka, Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(4152), new TimeSpan(0, 6, 0, 0, 0)), new DateOnly(1, 1, 1), false, null, null, null, 0, "http://biman-airlines.com" }
                });

            migrationBuilder.InsertData(
                table: "Airport",
                columns: new[] { "Id", "CityName", "Code", "CountryName", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "Name", "UpdateNo" },
                values: new object[,]
                {
                    { 1L, "Dhaka", "DAC", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7463), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Hazrat Shahjalal International Airport", 0 },
                    { 2L, "Chattogram", "CGP", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7483), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Shah Amanat International Airport", 0 },
                    { 3L, "Jashore", "JSR", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7485), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Jashore Airport", 0 },
                    { 4L, "Sylhet", "ZYL", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7487), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Osmany International Airport", 0 },
                    { 5L, "Comilla", "CLA", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7489), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Comilla Airport", 0 },
                    { 6L, "Ishurdi", "IRD", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7492), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Ishurdi Airport", 0 },
                    { 7L, "Cox's Bazar", "CXB", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7494), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Cox's Bazar Airport", 0 },
                    { 8L, "Saidpur", "SPD", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7496), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Saidpur Airport", 0 },
                    { 9L, "Rajshahi", "RJH", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7498), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Shah Makhdum Airport", 0 },
                    { 10L, "Barishal", "BZL", "Bangladesh", 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 43, DateTimeKind.Unspecified).AddTicks(7500), new TimeSpan(0, 6, 0, 0, 0)), false, null, null, "Barishal Airport", 0 }
                });

            migrationBuilder.InsertData(
                table: "Baggage",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "FlightClass", "IsDelete", "LuggageWeight", "ModifiedBy", "ModifiedDate", "UpdateNo" },
                values: new object[] { 1L, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Economy", false, 20.0, null, null, 0 });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "Id", "AircraftType", "AirlineId", "ArrivalAirportId", "ArrivalDate", "ArrivalTime", "BaggageId", "CreatedBy", "CreatedDate", "DepatureAirportId", "DepatureDate", "DepatureTime", "FlightDuration", "FlightNo", "FlightType", "IsDelete", "ModifiedBy", "ModifiedDate", "Price", "UpdateNo" },
                values: new object[,]
                {
                    { 1L, "B 787-8 Dreamliner", 1L, 7L, new DateOnly(2024, 1, 1), new TimeOnly(14, 0, 0), 1L, 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 47, DateTimeKind.Unspecified).AddTicks(6214), new TimeSpan(0, 6, 0, 0, 0)), 1L, new DateOnly(2024, 1, 1), new TimeOnly(11, 0, 0), new TimeSpan(0, 3, 0, 0, 0), "BG433", "Non-Stop", false, null, null, 5600.0, 0 },
                    { 2L, "B 787-8 Dreamliner", 2L, 7L, new DateOnly(2024, 1, 1), new TimeOnly(14, 0, 0), 1L, 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 47, DateTimeKind.Unspecified).AddTicks(6251), new TimeSpan(0, 6, 0, 0, 0)), 1L, new DateOnly(2024, 1, 1), new TimeOnly(11, 0, 0), new TimeSpan(0, 3, 0, 0, 0), "BS141", "Non-Stop", false, null, null, 5600.0, 0 },
                    { 3L, "B 787-8 Dreamliner", 3L, 7L, new DateOnly(2024, 1, 1), new TimeOnly(13, 30, 0), 1L, 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 47, DateTimeKind.Unspecified).AddTicks(6255), new TimeSpan(0, 6, 0, 0, 0)), 1L, new DateOnly(2024, 1, 1), new TimeOnly(11, 0, 0), new TimeSpan(0, 2, 30, 0, 0), "VQ927", "Non-Stop", false, null, null, 5600.0, 0 },
                    { 4L, "B 787-8 Dreamliner", 3L, 1L, new DateOnly(2024, 1, 1), new TimeOnly(19, 0, 0), 1L, 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 47, DateTimeKind.Unspecified).AddTicks(6258), new TimeSpan(0, 6, 0, 0, 0)), 7L, new DateOnly(2024, 1, 5), new TimeOnly(16, 30, 0), new TimeSpan(0, 2, 30, 0, 0), "VQ729", "Non-Stop", false, null, null, 5600.0, 0 },
                    { 5L, "B 787-8 Dreamliner", 2L, 1L, new DateOnly(2024, 1, 1), new TimeOnly(19, 0, 0), 1L, 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 47, DateTimeKind.Unspecified).AddTicks(6262), new TimeSpan(0, 6, 0, 0, 0)), 7L, new DateOnly(2024, 1, 5), new TimeOnly(16, 30, 0), new TimeSpan(0, 3, 0, 0, 0), "BS241", "Non-Stop", false, null, null, 5600.0, 0 },
                    { 6L, "B 787-8 Dreamliner", 1L, 1L, new DateOnly(2024, 1, 1), new TimeOnly(19, 0, 0), 1L, 1L, new DateTimeOffset(new DateTime(2024, 1, 9, 15, 44, 15, 47, DateTimeKind.Unspecified).AddTicks(6265), new TimeSpan(0, 6, 0, 0, 0)), 7L, new DateOnly(2024, 1, 5), new TimeOnly(16, 30, 0), new TimeSpan(0, 3, 0, 0, 0), "BG333", "Non-Stop", false, null, null, 5600.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineId",
                table: "Flight",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ArrivalAirportId",
                table: "Flight",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_BaggageId",
                table: "Flight",
                column: "BaggageId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepatureAirportId",
                table: "Flight",
                column: "DepatureAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelImages_HotelId",
                table: "HotelImages",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_FlightId",
                table: "Policy",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Stopover_AirportId",
                table: "Stopover",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Stopover_FlightId",
                table: "Stopover",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelImages");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DropTable(
                name: "Stopover");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Airline");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "Baggage");
        }
    }
}
