using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PokestopHotSpots.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotspots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GymCount = table.Column<int>(type: "int", nullable: false),
                    PokestopDensity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hasParking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotspots", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotspots",
                columns: new[] { "Id", "GymCount", "Name", "PokestopDensity", "hasParking" },
                values: new object[,]
                {
                    { 1, 6, "Lakefront Park", "High", true },
                    { 2, 4, "Veterans Park", "High", true },
                    { 3, 3, "Milwaukee Public Market", "High", false },
                    { 4, 4, "Historic Third Ward", "High", false },
                    { 5, 3, "Bradford Beach", "Medium", true },
                    { 6, 4, "Washington Park", "Medium", true },
                    { 7, 3, "Mitchell Park Domes", "Medium", true },
                    { 8, 2, "Humboldt Park", "Medium", true },
                    { 9, 2, "Bay View Park", "Low", true },
                    { 10, 2, "Kletzsch Park", "Low", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotspots");
        }
    }
}
