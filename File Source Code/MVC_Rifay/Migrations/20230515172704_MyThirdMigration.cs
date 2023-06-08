using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Rifay.Migrations
{
    /// <inheritdoc />
    public partial class MyThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bed_Count",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "active",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cancellation",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Food",
                table: "RoomCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bed_Count",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "active",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "cancellation",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Food",
                table: "RoomCategories");
        }
    }
}
