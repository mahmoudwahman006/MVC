using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Rifay.Migrations
{
    /// <inheritdoc />
    public partial class MyfourMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_RoomCategories_RoomCategoryId",
                table: "BookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomCategories_RoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomCategories",
                table: "RoomCategories");

            migrationBuilder.RenameTable(
                name: "RoomCategories",
                newName: "Room_Category");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Food",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RCFloor",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RCPrice",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Room_CategoryRoomCategoryId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room_Category",
                table: "Room_Category",
                column: "RoomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Room_CategoryRoomCategoryId",
                table: "Rooms",
                column: "Room_CategoryRoomCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_Room_Category_RoomCategoryId",
                table: "BookingDetails",
                column: "RoomCategoryId",
                principalTable: "Room_Category",
                principalColumn: "RoomCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Room_Category_Room_CategoryRoomCategoryId",
                table: "Rooms",
                column: "Room_CategoryRoomCategoryId",
                principalTable: "Room_Category",
                principalColumn: "RoomCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_Room_Category_RoomCategoryId",
                table: "BookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Room_Category_Room_CategoryRoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_Room_CategoryRoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room_Category",
                table: "Room_Category");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Food",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RCFloor",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RCPrice",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Room_CategoryRoomCategoryId",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Room_Category",
                newName: "RoomCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomCategories",
                table: "RoomCategories",
                column: "RoomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCategoryId",
                table: "Rooms",
                column: "RoomCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_RoomCategories_RoomCategoryId",
                table: "BookingDetails",
                column: "RoomCategoryId",
                principalTable: "RoomCategories",
                principalColumn: "RoomCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomCategories_RoomCategoryId",
                table: "Rooms",
                column: "RoomCategoryId",
                principalTable: "RoomCategories",
                principalColumn: "RoomCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
