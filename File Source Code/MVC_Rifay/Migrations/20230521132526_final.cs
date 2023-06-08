using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Rifay.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_CreditCards_credit_cardCreditCardId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_credit_cardCreditCardId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "credit_cardCreditCardId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "total_amount",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "BookingDetails");

            migrationBuilder.AddColumn<int>(
                name: "CardNumber",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "credit_cardCardNumber",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CreditCards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "CardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_credit_cardCardNumber",
                table: "Payments",
                column: "credit_cardCardNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_CreditCards_credit_cardCardNumber",
                table: "Payments",
                column: "credit_cardCardNumber",
                principalTable: "CreditCards",
                principalColumn: "CardNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_CreditCards_credit_cardCardNumber",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_credit_cardCardNumber",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "credit_cardCardNumber",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "credit_cardCreditCardId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CreditCards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "CreditCards",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<float>(
                name: "total_amount",
                table: "Bookings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "BookingDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "BookingDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_credit_cardCreditCardId",
                table: "Payments",
                column: "credit_cardCreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_CreditCards_credit_cardCreditCardId",
                table: "Payments",
                column: "credit_cardCreditCardId",
                principalTable: "CreditCards",
                principalColumn: "CreditCardId");
        }
    }
}
