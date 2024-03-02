using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlyNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialVisaRequirementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Country",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankTime",
                table: "Country",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CapitalCity",
                table: "Country",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Country",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmbassyAddress",
                table: "Country",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExchangeRate",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Country",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalTime",
                table: "Country",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelephoneCode",
                table: "Country",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TourismPlace",
                table: "Country",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VisaRequirement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    BasicDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForBusinessPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForJobHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForStudent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForMedical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Others = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisaRequirement_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "VisaRequirement",
                columns: new[] { "Id", "BasicDocument", "CountryId", "CreatedBy", "CreatedDate", "ForBusinessPerson", "ForJobHolder", "ForMedical", "ForStudent", "IsDelete", "ModifiedBy", "ModifiedDate", "Others", "UpdateNo", "VisaFee" },
                values: new object[,]
                {
                    { 1L, "Seven (07) Months Valid Passport with the last one Old Passport if have one (if an OLD passport is Lost then a GD copy with a translated notary must be required). Recent 2 copy photographs taken in the last 6 months (white background only, photo size 35 mm X 45 mm). Personal / Company Bank statement of the last 06 months with Bank Solvency Certificate (Minimum balance BDT 60,000 for each applicant). Visiting Card.", 12L, 1L, new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6111), new TimeSpan(0, 0, 0, 0, 0)), "Renewal Trade license copy with notary public (English Translated). Memorandum for Limited Company. Office Pad / Company Letter Head Pad.", "No Objection Certificate (NOC) from Employer (with an official Cell phone and TnT numbers). Visiting card. Mandatory official ID card copy. In the case of a Personal Account Statement (Savings Account) - need to provide the Salary Certificate/Payslip last 03 months. BMDC certificate for Doctor. BAR Council Certificate for Advocate. Retirement certificate for Retired Person. For Govt. employees - GO is required with an English translation notary must be required.", " In case of medical treatment, a copy of the appointment letter from a hospital in Thailand and if applicable, an original letter from a local doctor/hospital if the applicant is a first-time traveler. Recent case summary of the patient’s medical reports issued by the local hospital. Copy of recent certificate of acceptance for treatment/invitation letter from the receiving hospital in Thailand confirming the patient’s condition and the necessity of transfer to Thailand. The letter should mention the accompanying person's name(s) & relation, who will travel with the patient by Air Ambulance. Booking confirmation letter (such as Med letter & Action Plan) of an Air Ambulance.", "Student ID card copy.Birth Certificate (Only for Child & infant).Travel Letter or Leave Letter from the Educational Institute.", false, null, null, "Note: Marriage Certificate Copy or Nikahnama or the contract of marriage (if the spouse's name is not mentioned in the Applicant's passport). Note: Delivery Time (8 to 15) working days (Depend on Embassy). Note: Visa validity 3 months, single entry. Note: Visa rate can be changed without prior notice. Note: Visa issuance rights reserved by the Embassy.", 0, "BDT 4,900 (Non-refundable)" },
                    { 2L, "Seven (07) Months Valid Passport with Old Passport if have one. Visiting Card. Recent 2 copy photographs taken in the last 3 months (white background only, photo size 35 mm X 50 mm, Matt paper). Bank Statements last six months with a bank solvency certificate (Minimum balance BDT 60,000 for each applicant). Vaccine certificate copy (double dose). Hotel Booking Copy. Air Ticket Booking Copy.", 16L, 1L, new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6115), new TimeSpan(0, 0, 0, 0, 0)), "Renewal Trade license copy with notary public ( English Translated ). Memorandum for Limited Company. The blank page of the office pad.", "No Objection Certificate (NOC). BMDC certificate for Doctor. BAR Council Certificate for Advocate.", "", " Student ID card Photo Copy. Birth Certificate ( Only for Child & Infant).", false, null, null, "Note: Marriage Certificate Copy (For family application only) One Country Visit is required - Except India, Nepal, Sri Lanka, Maldives, Bhutan, and UAE. Note: Delivery Time (25 to 30) working days Minimum. Note: Visa validity 6 months, Single entry - E-Visa. Note: Visa rate can be changed without prior notice. Note: Visa issuance rights are reserved by the Embassy.", 0, "BDT 3,900 ( Non-refundable )" },
                    { 3L, "Recent Valid Passport & All Previous passports. Last Indian visa copy (if any). NID copy (Both Side). Recent 1 Copy Photo (2\"x2\", white background, glossy/matte paper). Latest Utility (Electricity/Gas/Water) bill copy. NOC from the company - (If doing any job). Salary Certificate. Trade License- If Business. Visiting card/Employee ID card (Both Side). Bank statement of last 06 months/Dollar endorsement certificate (at least USD $200). Student ID Card copy (Both Side) and Birth Certificate (If Student). Previous SAARC visited country name  & year of visit - if any. Previous NON-SAARC visited country name - if any.", 17L, 1L, new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6117), new TimeSpan(0, 0, 0, 0, 0)), " Profession proof. Tin, Tax certificate. Invitation letter. IRC/ERC. LC / Dual party Agreement. Association certificate.", "", "Medical Invitation letter from India with a specific date. All Medical original documents. Profession proof.", "", false, null, null, "", 0, "ST processing & Embassy BDT 1,500/-" },
                    { 4L, "Valid passport copy (Must be clear). Confirm Air Ticket. Confirm Hotel.", 7L, 1L, new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 0, 0, 0, 0)), "", "", "", "", false, null, null, "Note: Delivery time (1-2 Working days)", 0, "Per person BDT 3,400/- (Non-refundable)" },
                    { 5L, "Seven (07) months valid passport with an old passport if you have one. Visiting card. NID / Birth certificate copy. Recent 2 copy photographs taken in the last 3 months (matt paper, white background only). 35 mm in width x 45mm in height. For First time visit to Singapore - Bank Statement and Solvency certificate are required (with a minimum BDT 80,000 ending balance). V39A Invitation. Confirmed Hotel booking copy. Air ticket booking copy.", 15L, 1L, new DateTimeOffset(new DateTime(2024, 2, 29, 10, 32, 18, 596, DateTimeKind.Unspecified).AddTicks(6122), new TimeSpan(0, 0, 0, 0, 0)), "Renewal trade license copy with notary public ( English Translated ). Memorandum for limited company / Form XII. The blank page of office pad.", "No objection certificate (NOC). BMDC certificate for Doctor . BAR Council certificate for Advocate. Retirement document for Retired Person.", "", "Student ID card Photo Copy. NOC from College/University. Birth certificate (Only for Child & infant).", false, null, null, "Note: Marriage certificate copy (if spouse's name is not mentioned in the Passport). Note: Visa rate can change without prior notice. Note: Delivery time (7 to 10) working days. Note: Visa validity is 60 days. Note: Visa issuance rights are reserved by the Embassy.", 0, "Visa Fee Per Person: BDT 3,900 (Without LOI support) and BDT 4,100 with LOI support. (Non-refundable)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisaRequirement_CountryId",
                table: "VisaRequirement",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisaRequirement");

            migrationBuilder.DropColumn(
                name: "BankTime",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CapitalCity",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "EmbassyAddress",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "LocalTime",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "TelephoneCode",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "TourismPlace",
                table: "Country");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(85)",
                oldMaxLength: 85,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

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
        }
    }
}
