using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDetail_Carts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "ImagePath", "Name", "Status", "UpdateDate" },
<<<<<<<< HEAD:ECommerce.Infrastructure/Migrations/20240405075720_init.cs
                values: new object[,]
                {
<<<<<<<< HEAD:ECommerce.Infrastructure/Migrations/20240405075720_init.cs
                    { 1, new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9095), null, "Çakmak", null, "Çok Amaçlı", 1, null },
                    { 2, new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9105), null, "Çakmak", null, "Mumlar İçin", 1, null },
                    { 3, new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9106), null, "Aksesuar", null, "Cüzdan", 1, null },
                    { 4, new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9107), null, "Aksesuar", null, "Gözlük", 1, null },
                    { 5, new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9108), null, "Aksesuar", null, "Kalem", 1, null }
========
                    { 1, new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4247), null, "Çakmak", null, "Çok Amaçlı", 1, null },
                    { 2, new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4259), null, "Çakmak", null, "Mumlar İçin", 1, null },
                    { 3, new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4261), null, "Aksesuar", null, "Cüzdan", 1, null },
                    { 4, new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4262), null, "Aksesuar", null, "Gözlük", 1, null },
                    { 5, new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4263), null, "Aksesuar", null, "Kalem", 1, null }
>>>>>>>> origin/damla:ECommerce.Infrastructure/Migrations/20240405080758_initial.cs
                });
========
                values: new object[] { 1, new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(5948), null, "Çakmak", null, "Çok Amaçlı", 1, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "ImagePath", "Name", "Status", "UpdateDate" },
                values: new object[] { 2, new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(5958), null, "Çakmak", null, "Mumlar İçin", 1, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "ImagePath", "Name", "Status", "UpdateDate" },
                values: new object[] { 3, new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(5959), null, "Aksesuar", null, "Aksesuar", 1, null });
>>>>>>>> origin/Atalay:ECommerce.Infrastructure/Migrations/20240405081806_init.cs

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "CreateDate", "DeleteDate", "Description", "ImagePath", "Name", "Price", "Quantity", "Status", "UpdateDate" },
                values: new object[,]
                {
<<<<<<<< HEAD:ECommerce.Infrastructure/Migrations/20240405075720_init.cs
<<<<<<<< HEAD:ECommerce.Infrastructure/Migrations/20240405075720_init.cs
                    { 1, 1, "Kırmızı", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9184), null, "Bu ürünün açıklaması 1", "../../images/00285a53-201b-475e-b056-31b524c0354c.jpg", "çakmak 1", 100m, 10, 1, null },
                    { 2, 1, "Mavi", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9186), null, "Bu ürünün açıklaması 2", "../../images/00ca64ae-faaa-4235-bd98-a4bb4623bfc2.jpg", "çakmak 2", 150m, 5, 1, null },
                    { 3, 2, "Yeşil", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9187), null, "Bu ürünün açıklaması 3", "~/images/Default.png", "çakmak 3", 200m, 8, 1, null },
                    { 4, 2, "Sarı", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9189), null, "Bu ürünün açıklaması 4", "~/images/Default.png", "çakmak 4", 120m, 12, 1, null },
                    { 5, 2, "Mor", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9190), null, "Bu ürünün açıklaması 5", "~/images/9c11630d-b841-4242-9bf1-8bd8405f507a.jpg", "çakmak 5", 180m, 6, 1, null },
                    { 6, 3, "Mavi", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9193), null, "Bu ürünün açıklaması 1", "images/Aksesuar1.jpg", "Cüzdan 1", 150m, 5, 1, null },
                    { 7, 3, "Kırmızı", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9194), null, "Bu ürünün açıklaması 2", "~/images/9c11630d-b841-4242-9bf1-8bd8405f507a.jpg", "Cüzdan 2", 150m, 5, 1, null },
                    { 8, 4, "Kırmızı", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9195), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Gözlük 1", 150m, 5, 1, null },
                    { 9, 4, "Kırmızı", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9196), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Gözlük 2", 150m, 5, 1, null },
                    { 10, 5, "Kırmızı", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9197), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Kalem 1", 150m, 5, 1, null },
                    { 11, 5, "Kırmızı", new DateTime(2024, 4, 5, 10, 57, 19, 821, DateTimeKind.Local).AddTicks(9199), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Kaelm 2", 150m, 5, 1, null }
========
                    { 1, 1, "Kırmızı", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4394), null, "Bu ürünün açıklaması 1", "../../images/00285a53-201b-475e-b056-31b524c0354c.jpg", "çakmak 1", 100m, 10, 1, null },
                    { 2, 1, "Mavi", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4397), null, "Bu ürünün açıklaması 2", "../../images/00ca64ae-faaa-4235-bd98-a4bb4623bfc2.jpg", "çakmak 2", 150m, 5, 1, null },
                    { 3, 2, "Yeşil", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4400), null, "Bu ürünün açıklaması 3", "~/images/Default.png", "çakmak 3", 200m, 8, 1, null },
                    { 4, 2, "Sarı", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4402), null, "Bu ürünün açıklaması 4", "~/images/Default.png", "çakmak 4", 120m, 12, 1, null },
                    { 5, 2, "Mor", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4404), null, "Bu ürünün açıklaması 5", "~/images/9c11630d-b841-4242-9bf1-8bd8405f507a.jpg", "çakmak 5", 180m, 6, 1, null },
                    { 6, 3, "Mavi", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4406), null, "Bu ürünün açıklaması 1", "images/Aksesuar1.jpg", "Cüzdan 1", 150m, 5, 1, null },
                    { 7, 3, "Kırmızı", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4407), null, "Bu ürünün açıklaması 2", "~/images/9c11630d-b841-4242-9bf1-8bd8405f507a.jpg", "Cüzdan 2", 150m, 5, 1, null },
                    { 8, 4, "Kırmızı", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4409), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Gözlük 1", 150m, 5, 1, null },
                    { 9, 4, "Kırmızı", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4411), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Gözlük 2", 150m, 5, 1, null },
                    { 10, 5, "Kırmızı", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4413), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Kalem 1", 150m, 5, 1, null },
                    { 11, 5, "Kırmızı", new DateTime(2024, 4, 5, 11, 7, 57, 971, DateTimeKind.Local).AddTicks(4415), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Kaelm 2", 150m, 5, 1, null }
>>>>>>>> origin/damla:ECommerce.Infrastructure/Migrations/20240405080758_initial.cs
========
                    { 1, 1, "Kırmızı", new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(6045), null, "Bu ürünün açıklaması 1", "~/images/Default.png", "çakmak 1", 100m, 10, 1, null },
                    { 2, 2, "Mavi", new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(6047), null, "Bu ürünün açıklaması 2", "~/images/Default.png", "çakmak 2", 150m, 5, 1, null },
                    { 3, 1, "Yeşil", new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(6049), null, "Bu ürünün açıklaması 3", "~/images/Default.png", "çakmak 3", 200m, 8, 1, null },
                    { 4, 2, "Sarı", new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(6050), null, "Bu ürünün açıklaması 4", "~/images/Default.png", "çakmak 4", 120m, 12, 1, null },
                    { 5, 1, "Mor", new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(6052), null, "Bu ürünün açıklaması 5", "~/images/9c11630d-b841-4242-9bf1-8bd8405f507a.jpg", "çakmak 5", 180m, 6, 1, null },
                    { 6, 3, "Mavi", new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(6053), null, "Bu ürünün açıklaması 2", "~/images/9c11630d-b841-4242-9bf1-8bd8405f507a.jpg", "Aksesuar 1", 150m, 5, 1, null },
                    { 7, 3, "Kırmızı", new DateTime(2024, 4, 5, 11, 18, 6, 113, DateTimeKind.Local).AddTicks(6054), null, "Bu ürünün açıklaması 2", "~/images/9c11630d-b841-4242-9bf1-8bd8405f507a.jpg", "Aksesuar 2", 150m, 5, 1, null }
>>>>>>>> origin/Atalay:ECommerce.Infrastructure/Migrations/20240405081806_init.cs
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_ProductId",
                table: "CartDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_ShoppingCartId",
                table: "CartDetail",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
