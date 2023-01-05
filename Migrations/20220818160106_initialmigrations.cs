using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomStart.Migrations
{
    public partial class initialmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFirst = table.Column<string>(name: "Name(First)", type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameLast = table.Column<string>(name: "Name(Last)", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "product category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(name: "Category Name", type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product category", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductCategoryID = table.Column<int>(name: "Product Category ID", type: "int(11)", nullable: false),
                    ProductName = table.Column<string>(name: "Product Name", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantityOnHand = table.Column<int>(name: "Quantity On Hand", type: "int(11)", nullable: false),
                    Minimum = table.Column<int>(type: "int(11)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ID);
                    table.ForeignKey(
                        name: "products_ibfk_1",
                        column: x => x.ProductCategoryID,
                        principalTable: "product category",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(name: "Customer ID", type: "int(11)", nullable: false),
                    ProductCategoryID = table.Column<int>(name: "Product Category ID", type: "int(11)", nullable: false),
                    ProductNameID = table.Column<int>(name: "Product Name ID", type: "int(11)", nullable: false),
                    TimeDateofOrder = table.Column<DateTime>(name: "Time/Date of Order", type: "datetime", nullable: false),
                    QuantityOrdered = table.Column<int>(name: "Quantity Ordered", type: "int(11)", nullable: false),
                    IndividualPrice = table.Column<decimal>(name: "Individual Price", type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ExtendedPrice = table.Column<decimal>(name: "Extended Price", type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(name: "Total Price", type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.ID);
                    table.ForeignKey(
                        name: "transactions_ibfk_1",
                        column: x => x.CustomerID,
                        principalTable: "customer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "transactions_ibfk_2",
                        column: x => x.ProductCategoryID,
                        principalTable: "product category",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "transactions_ibfk_3",
                        column: x => x.ProductNameID,
                        principalTable: "products",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "ID", "Address", "Name(First)", "Name(Last)", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "321 Elm Street", "Phil", "Esposito", "290-933-5657" },
                    { 2, "20 Compton Way", "Eric", "Clapton", "644-379-6163" },
                    { 3, "777 GTA V Street", "Bill", "Murray", "871-972-7144" },
                    { 4, "11 White House", "Nancy", "Peluso", "672-359-1685" },
                    { 5, "99 Beachwood Lane", "Sandy", "Seashore", "331-423-0749" },
                    { 6, "560 Hellsgate Inn", "Sara", "Bigwood", "976-832-8846" },
                    { 7, "411 Eagle Street", "Peter", "Gabriel", "407-321-1120" },
                    { 8, "100 Acre Woods", "Winnie", "DaPooh", "703-814-7093" },
                    { 9, "99 Peanuts Avenue", "Charlie", "Brown", "565-734-5713" },
                    { 10, "#2 Air Tonite Way", "Phil", "Collins", "490-817-3191" }
                });

            migrationBuilder.InsertData(
                table: "product category",
                columns: new[] { "ID", "Category Name" },
                values: new object[,]
                {
                    { 1, "Paint" },
                    { 2, "SandPaper" },
                    { 3, "Filler" },
                    { 4, "PPE" },
                    { 5, "Shop Supplies" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ID", "Cost", "Minimum", "Product Category ID", "Product Name", "Quantity On Hand", "SalePrice" },
                values: new object[,]
                {
                    { 1, 225.00m, 4, 1, "White Toner", 6, 360.000m },
                    { 2, 200.00m, 4, 1, "Black Toner", 3, 320.000m },
                    { 3, 600.00m, 4, 1, "Red Toner", 5, 960.000m },
                    { 4, 500.00m, 4, 1, "Orange Toner", 5, 800.000m },
                    { 5, 550.00m, 3, 1, "Yellow Toner", 2, 880.000m },
                    { 6, 325.00m, 4, 1, "Green Toner", 4, 520.000m },
                    { 7, 420.00m, 4, 1, "Blue Toner", 4, 672.000m },
                    { 8, 575.00m, 4, 1, "Indigo Toner", 4, 920.000m },
                    { 9, 750.00m, 4, 1, "Violet Toner", 2, 1200.000m },
                    { 10, 65.00m, 6, 1, "Gun Wash", 10, 104.000m },
                    { 11, 75.00m, 5, 2, "180 Grit Sandpaper", 8, 120.000m },
                    { 12, 75.00m, 5, 2, "220 Grit Sandpaper", 9, 120.000m },
                    { 13, 85.00m, 5, 2, "320 Grit Sandpaper", 6, 136.000m },
                    { 14, 85.00m, 5, 2, "400 Grit Sandpaper", 6, 136.000m },
                    { 15, 85.00m, 5, 2, "600 Grit Sandpaper", 3, 136.000m },
                    { 16, 85.00m, 5, 2, "800 Grit Sandpaper", 6, 136.000m },
                    { 17, 55.00m, 5, 2, "1500 Grit Sandpaper", 6, 88.000m },
                    { 18, 35.00m, 5, 3, "Bronze Bondo", 6, 56.000m },
                    { 19, 45.00m, 5, 3, "Silver Bondo", 4, 72.000m },
                    { 20, 65.00m, 5, 3, "Gold Bondo", 1, 104.000m },
                    { 21, 30.00m, 5, 3, "Finishing Putty", 4, 48.000m },
                    { 22, 45.00m, 10, 4, "Coveralls", 4, 72.000m },
                    { 23, 45.00m, 6, 4, "Respirator", 4, 72.000m },
                    { 24, 30.00m, 65, 4, "Gloves", 15, 48.000m },
                    { 25, 10.00m, 65, 5, "Rags", 15, 16.000m },
                    { 26, 5.00m, 65, 5, "Razor Blades", 75, 8.000m },
                    { 27, 40.00m, 10, 5, "Masking Paper", 15, 64.000m },
                    { 28, 6.00m, 65, 5, "Masking Tape", 155, 9.600m }
                });

            migrationBuilder.CreateIndex(
                name: "Product Category ID",
                table: "products",
                column: "Product Category ID");

            migrationBuilder.CreateIndex(
                name: "Customer ID",
                table: "transactions",
                column: "Customer ID");

            migrationBuilder.CreateIndex(
                name: "Product Category ID1",
                table: "transactions",
                column: "Product Category ID");

            migrationBuilder.CreateIndex(
                name: "Product Name ID",
                table: "transactions",
                column: "Product Name ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "product category");
        }
    }
}
