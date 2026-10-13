using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokestopHotSpots.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hotspots",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A beautiful park along the lakefront with plenty of Pokestops and gyms.");

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A popular park with a high density of Pokestops and gyms, perfect for Pokemon Go players.");

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "A vibrant market with a variety of shops and eateries.");

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "A historic neighborhood with a rich cultural heritage.");

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "A lovely beach with a great view and plenty of space to play.");

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "A large park with a variety of recreational activities and a moderate density of Pokestops and gyms.");

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "A beautiful conservatory with a variety of plants and flowers.");

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "A peaceful park with a variety of trees and green spaces.");

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "A quiet park with a peaceful atmosphere and a low density of Pokestops and gyms.");

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "A small park with a peaceful atmosphere and a low density of Pokestops and gyms.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hotspots");
        }
    }
}
