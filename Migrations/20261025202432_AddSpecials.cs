using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokestopHotSpots.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotspotRegulars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FriendshipCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    SendsDailyGifts = table.Column<bool>(type: "bit", nullable: false),
                    HotspotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotspotRegulars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotspotRegulars_Hotspots_HotspotId",
                        column: x => x.HotspotId,
                        principalTable: "Hotspots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotspotRegulars_HotspotId",
                table: "HotspotRegulars",
                column: "HotspotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotspotRegulars");
        }
    }
}
