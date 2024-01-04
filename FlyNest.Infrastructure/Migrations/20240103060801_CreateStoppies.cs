using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyNest.Infrastructure.Migrations
{
    /// <inheritdoc/>
    public partial class CreateStoppies : Migration
    {
        /// <inheritdoc/>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stoppies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoppies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stoppies_Airport_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(name: "IX_Stoppies_AirportId", table: "Stoppies", column: "AirportId");
        }

        /// <inheritdoc/>
        protected override void Down(MigrationBuilder migrationBuilder)
        { migrationBuilder.DropTable(name: "Stoppies"); }
    }
}
