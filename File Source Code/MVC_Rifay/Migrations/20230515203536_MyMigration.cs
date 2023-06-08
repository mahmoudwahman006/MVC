using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Rifay.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_Room_Category_RoomCategoryId",
                table: "BookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Room_Category_Room_CategoryRoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Room_Category");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_Room_CategoryRoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_RoomCategoryId",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "RoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Room_CategoryRoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomCategoryId",
                table: "BookingDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RoomCategoryId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Room_CategoryRoomCategoryId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomCategoryId",
                table: "BookingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Room_Category",
                columns: table => new
                {
                    RoomCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Food = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RCFloor = table.Column<int>(type: "int", nullable: false),
                    RCPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Category", x => x.RoomCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Room_CategoryRoomCategoryId",
                table: "Rooms",
                column: "Room_CategoryRoomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_RoomCategoryId",
                table: "BookingDetails",
                column: "RoomCategoryId",
                unique: true);

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
    }
}
