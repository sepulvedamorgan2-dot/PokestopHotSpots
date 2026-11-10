using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokestopHotSpots.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainerNameAndFriendCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FriendshipCode",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrainerName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendshipCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TrainerName",
                table: "AspNetUsers");
        }
    }
}
