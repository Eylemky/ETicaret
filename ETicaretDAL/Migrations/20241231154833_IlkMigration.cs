using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ETicaretDAL.Migrations
{
    /// <inheritdoc />
    public partial class IlkMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    SiteSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.SiteSettingId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.CategoriesCategoryId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    RequiredDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ShippedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "OrderStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Elbise", "Kadın ve Kız Çocuk Giyim" },
                    { 2, "Etek", "Kadın ve Kız Çocuk Giyim" },
                    { 3, "Mont", "Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim" },
                    { 4, "T-Shirt", "Yazlık kaliteli Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim" },
                    { 5, "Kazak", "Kışlık kaliteli Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim" },
                    { 6, "Pantolon", "Mevsimlik kaliteli Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim" },
                    { 7, "Gömlek", "Mevsimlik kaliteli Kadın, Erkek ve Kız Çocuk, Erkek Çocuk giyim" },
                    { 8, "Gözlük", "Aksesuar" },
                    { 9, "Flor", "Aksesuar" },
                    { 10, "Abiye Çanta", "Çanta" },
                    { 11, " Günlük Çanta", "Çanta" },
                    { 12, "Sırt Çantası", "Çanta" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "OrderStatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Completed" },
                    { 3, "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsActive", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8389), "%100 Pamuk kazak", true, "Triko Kazak", 200m, 243, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8390) },
                    { 2, 1, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8393), "Müslim kumaş mevsimlik", true, " Elbise", 460m, 243, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8394) },
                    { 3, 4, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8396), "Mevsimlik", true, " T-Shirt", 347m, 243, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8396) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Customer" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "SiteSettingId", "Key", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, "SiteTitle", null, "My E-Store Website" },
                    { 2, "SiteDescription", null, "The best e-store platform to meet all your needs!" },
                    { 3, "ContactEmail", null, "support@myestore.com" },
                    { 4, "ContactPhone", null, "0 850 444 8 444" },
                    { 5, "DefaultCurrency", null, "USD" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "IsActive", "Name", "PasswordHash", "PhoneNumber", "RoleId", "Surname", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8706), "felixruntenten@gmail.com", true, "Felix", "qweasd", "+90 555 333 55 33", 1, "Runtenten", new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8707) },
                    { 2, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8709), "fahri_feneroğlu@gmail.com", true, "Fahri", "qweasd1", "+90 535 555 35 44", 1, "Feneroğlu", new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8710) },
                    { 3, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8712), "iremozyurt@gmail.com", true, "İrem", "qweasd2", "+90 555 444 22 34", 1, "Çelik", new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8712) },
                    { 4, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8714), "ademdonmez@gmail.com", true, "Adem", "qweasd3", "+90 532 625 54 34", 1, "Donmez", new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8715) },
                    { 5, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8717), "jush_hutcersen@gmail.com", true, "Jush", "qweasd4", "+90 555 435 33 55", 1, "Hutcerson", new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8717) },
                    { 6, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8719), "eylemdonmez@admin.com", true, "Eylem", "qweasdadmin", "+90 555 465 88 22", 2, "Kaya Donmez", new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8720) },
                    { 7, new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8722), "ercanozturk@admin.com", true, "Ercan", "qweasdpro", "+90 555 425 55 24", 2, "Öztürk", new DateTime(2024, 12, 31, 18, 48, 33, 123, DateTimeKind.Local).AddTicks(8722) }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "AddressDescription", "AddressLine", "City", "State", "UserId" },
                values: new object[,]
                {
                    { 1, "Barış Caddesi, Sümbül Sokağı, Kuş Apartmanı No:34 / Daire:4", "Home", "İstanbul", "Kadıköy", 1 },
                    { 2, "Çağla Mahallesi, Martı Apartmanı No:21 Daire:8", "Annemler", "Samsun", "Mustafakemalpaşa", 5 },
                    { 3, "Yaşar Sokak, Sarnış Apt. No:6 Daire:1", "Evim", "İzmir", "Karşıyaka", 3 },
                    { 4, "Atatürk Mahallesi, Savaş Sokak, Cumhuriyet Apt. No:18 Daire:3", "Office", "İstanbul", "Maltepe", 2 },
                    { 5, "Sarıca  Mh. , Pervane Sokak, Özdemir Sitesi G Blok Daire:13", "IlkEvim", "Ankara", "Çankaya", 4 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "OrderStatusId", "PaymentMethod", "RequiredDate", "ShippedDate", "ShippingAddress", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 6, 5), 1, "Card", new DateOnly(2024, 6, 10), new DateOnly(2024, 6, 8), "Barış Caddesi, Sümbül Sokağı, Kuş Apartmanı No:34 / Daire:4", "Pending", 250m, 3 },
                    { 2, new DateOnly(2024, 10, 18), 2, "CreditCard", new DateOnly(2024, 10, 22), new DateOnly(2024, 10, 20), "Çağla Mahallesi, Martı Apartmanı No:21 Daire:8", "Completed", 250m, 3 },
                    { 3, new DateOnly(2024, 4, 30), 3, "CreditCard", new DateOnly(2024, 5, 4), new DateOnly(2024, 5, 3), "Yaşar Sokak, Sarnış Apt. No:6 Daire:1", "Canceled", 250m, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 200m },
                    { 2, 2, 2, 4, 300m }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "IsSuccessful", "OrderId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 150.50m, true, 1, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard" },
                    { 2, 200.00m, true, 2, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "PayPal" },
                    { 3, 99.99m, false, 3, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductsId",
                table: "ProductCategory",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_Key",
                table: "SiteSettings",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
