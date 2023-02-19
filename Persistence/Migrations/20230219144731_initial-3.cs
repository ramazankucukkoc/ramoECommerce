using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoices",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 19, 17, 47, 31, 91, DateTimeKind.Local).AddTicks(6551),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 2, 10, 21, 9, 52, 476, DateTimeKind.Local).AddTicks(2661));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Invoices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalSum",
                table: "Invoices",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Address",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProductId",
                table: "Invoices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Countries_CountryId",
                table: "Address",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Products_ProductId",
                table: "Invoices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Countries_CountryId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Products_ProductId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ProductId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Address_CountryId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TotalSum",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Address");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoices",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 10, 21, 9, 52, 476, DateTimeKind.Local).AddTicks(2661),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 2, 19, 17, 47, 31, 91, DateTimeKind.Local).AddTicks(6551));
        }
    }
}
