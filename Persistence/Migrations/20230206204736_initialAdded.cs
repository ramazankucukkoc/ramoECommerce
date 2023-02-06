using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initialAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_RentalBranches_ProductBranchId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalBranches",
                table: "RentalBranches");

            migrationBuilder.RenameTable(
                name: "RentalBranches",
                newName: "ProductBranches");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoices",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 6, 23, 47, 36, 413, DateTimeKind.Local).AddTicks(1535),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 2, 6, 23, 44, 18, 614, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBranches",
                table: "ProductBranches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBranches_ProductBranchId",
                table: "Products",
                column: "ProductBranchId",
                principalTable: "ProductBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBranches_ProductBranchId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBranches",
                table: "ProductBranches");

            migrationBuilder.RenameTable(
                name: "ProductBranches",
                newName: "RentalBranches");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoices",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 6, 23, 44, 18, 614, DateTimeKind.Local).AddTicks(8121),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 2, 6, 23, 47, 36, 413, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalBranches",
                table: "RentalBranches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RentalBranches_ProductBranchId",
                table: "Products",
                column: "ProductBranchId",
                principalTable: "RentalBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
