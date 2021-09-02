using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddProductIamgeAndCompanyTablesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Toys");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Toys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductImageId",
                table: "Toys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Toys_ProductImageId",
                        column: x => x.ProductImageId,
                        principalTable: "Toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Company 1" },
                    { 2, "Company 2" },
                    { 3, "Company 3" },
                    { 4, "Company 4" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Image", "ProductImageId" },
                values: new object[,]
                {
                    { 1, new byte[] { 32, 32, 32, 32, 32 }, null },
                    { 2, new byte[] { 32, 32, 32, 32, 32 }, null },
                    { 3, new byte[] { 32, 32, 32, 32, 32 }, null },
                    { 4, new byte[] { 32, 32, 32, 32, 32 }, null }
                });

            migrationBuilder.InsertData(
                table: "Toys",
                columns: new[] { "Id", "AgeRestriction", "CompanyId", "Description", "Name", "Price", "ProductImageId" },
                values: new object[,]
                {
                    { 1, 5, 1, "This is a toy", "MyToy 1", 15m, 1 },
                    { 2, 5, 2, "This is a toy", "MyToy 2", 15m, 2 },
                    { 3, 5, 3, "This is a toy", "MyToy 3", 15m, 3 },
                    { 4, 5, 4, "This is a toy", "MyToy 4", 15m, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toys_CompanyId",
                table: "Toys",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductImageId",
                table: "ProductImages",
                column: "ProductImageId",
                unique: true,
                filter: "[ProductImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Companies_CompanyId",
                table: "Toys",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Companies_CompanyId",
                table: "Toys");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_Toys_CompanyId",
                table: "Toys");

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "ProductImageId",
                table: "Toys");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Toys",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Toys",
                type: "nvarchar(280)",
                maxLength: 280,
                nullable: true);
        }
    }
}
