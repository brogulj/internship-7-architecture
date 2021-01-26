using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OIB = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartOfShift = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfShift = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Validity = table.Column<bool>(type: "bit", nullable: false),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleType = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AmmountLeft = table.Column<int>(type: "int", nullable: false),
                    AmmountSold = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    SaleType = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryOffer",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    OffersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOffer", x => new { x.CategoriesId, x.OffersId });
                    table.ForeignKey(
                        name: "FK_CategoryOffer_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryOffer_Offers_OffersId",
                        column: x => x.OffersId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ammount = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SaleType = table.Column<int>(type: "int", nullable: false),
                    Validity = table.Column<bool>(type: "bit", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Building" },
                    { 2, "Clothing" },
                    { 3, "Food" },
                    { 4, "Vehicles" },
                    { 5, "Music" },
                    { 6, "Pets" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "OIB" },
                values: new object[,]
                {
                    { 1, "Marko", "Markic", "12345" },
                    { 2, "Mirko", "Mirkic", "54321" },
                    { 3, "Sune", "Sunic", "76543" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Availability", "EndOfShift", "FirstName", "LastName", "StartOfShift" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Mate", "Matic", new DateTime(2020, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, new DateTime(2020, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "Ivanovic", new DateTime(2020, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, new DateTime(2020, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Jovan", "Jovic", new DateTime(2020, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AmmountLeft", "AmmountSold", "Availability", "EmployeeId", "Name", "Price", "SaleType" },
                values: new object[,]
                {
                    { 1, 30, 0, true, null, "Gitara", 500, 1 },
                    { 3, 100, 0, true, null, "Dog Food", 10, 1 },
                    { 4, 50, 0, true, null, "White t-shirt", 30, 1 },
                    { 5, 10000000, 0, true, null, "Monthly Repairs", 100, 2 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AmmountLeft", "AmmountSold", "Availability", "EmployeeId", "Name", "Price", "SaleType" },
                values: new object[] { 2, 1000, 0, true, 1, "Car Wash", 50, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOffer_OffersId",
                table: "CategoryOffer",
                column: "OffersId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_EmployeeId",
                table: "Offers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BillId",
                table: "Sales",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_OfferId",
                table: "Sales",
                column: "OfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryOffer");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
