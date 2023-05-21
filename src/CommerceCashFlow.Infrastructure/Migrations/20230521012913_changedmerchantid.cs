using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceCashFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedmerchantid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Merchants_MerchantId1",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_MerchantId1",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "MerchantId1",
                table: "Reports");

            migrationBuilder.AlterColumn<double>(
                name: "TotalDebit",
                table: "Reports",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCredit",
                table: "Reports",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "OpeningBalance",
                table: "Reports",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.DropColumn(
               name: "MerchantId",
               table: "Reports");

            migrationBuilder.AddColumn<Guid>(
                name: "MerchantId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MerchantId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "ClosingBalance",
                table: "Reports",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MerchantId",
                table: "Reports",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Merchants_MerchantId",
                table: "Reports",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Merchants_MerchantId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_MerchantId",
                table: "Reports");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDebit",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCredit",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "Reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<decimal>(
                name: "ClosingBalance",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<Guid>(
                name: "MerchantId1",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MerchantId1",
                table: "Reports",
                column: "MerchantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Merchants_MerchantId1",
                table: "Reports",
                column: "MerchantId1",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
