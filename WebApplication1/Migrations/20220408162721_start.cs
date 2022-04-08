using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNamr = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    State = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    ZipCode = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Varienty = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                columns: table => new
                {
                    SalesPersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    State = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    ZipCode = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.SalesPersonId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Orders_SalesPerson",
                        column: x => x.SalesPersonId,
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QuanTity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_OrderItems_Products",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SalesPersonId",
                table: "Orders",
                column: "SalesPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "SalesPerson");
        }
    }
}
