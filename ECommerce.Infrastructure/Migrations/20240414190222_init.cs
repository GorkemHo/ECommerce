using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infrastructure.Migrations
{
    public partial class init : Migration
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
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
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
                    PaymentType = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_ProductOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "ImagePath", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5903), null, "Çakmak", null, "Çok Amaçlı", 1, null },
                    { 2, new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5912), null, "Çakmak", null, "Mumlar İçin", 1, null },
                    { 3, new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5913), null, "Aksesuar", null, "Cüzdan", 1, null },
                    { 4, new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5913), null, "Aksesuar", null, "Gözlük", 1, null },
                    { 5, new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5914), null, "Aksesuar", null, "Kalem", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "CreateDate", "DeleteDate", "Description", "ImagePath", "Name", "Price", "Quantity", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, "Kırmızı", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5993), null, "• Kaplama: Red Matte\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım", "../../images/cakmak/cakmak-kirmizi.jpg", "Çakmak", 100m, 10, 1, null },
                    { 2, 1, "Mavi", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5994), null, "• Kaplama: Indigo\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım", "../../images/cakmak/cakmak-mavi.jpg", "Çakmak", 150m, 5, 1, null },
                    { 3, 1, "Yeşil", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5996), null, "• Kaplama: Green Matte\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım", "../../images/cakmak/cakmak-yesil.jpg", "Çakmak", 200m, 8, 1, null },
                    { 4, 1, "Siyah", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5998), null, "• Kaplama: Black Matte\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım", "../../images/cakmak/cakmak-siyah.jpg", "Çakmak", 120m, 12, 1, null },
                    { 5, 1, "Beyaz", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(5999), null, "• Kaplama: White Matte\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım", "../../images/cakmak/cakmak-beyaz.jpg", "Çakmak", 180m, 6, 1, null },
                    { 6, 2, "Siyah", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6001), null, "Romantik bir akşam yemeği için mumlar hazır mı? Güzel bir akşam yemeğinde mumları yakmayı Zippo Mum Çakmağına bırakın. Fırçalanmış krom renkli Mum çakmağı yumuşak bir dokunmayla yanmaya hazır sistemi, ayarlanilir alev çıkışı, patentli çocuk-resistans kilidi ve baştan uca 16,5 cm uzunluğunda. Fırçalanmış krom rengine sahip mum çakmağı 3-yıl garantiye sahiptir. Optimum yanma performansı için Zippo Premium Bütan gazı kullanılması önerilir.Romantik bir akşam yemeği için mumlar hazır mı? Güzel bir akşam yemeğinde mumları yakmayı Zippo Mum Çakmağına bırakın. Fırçalanmış krom renkli Mum çakmağı yumuşak bir dokunmayla yanmaya hazır sistemi, ayarlanilir alev çıkışı, patentli çocuk-resistans kilidi ve baştan uca 16,5 cm uzunluğunda. Fırçalanmış krom rengine sahip mum çakmağı 3-yıl garantiye sahiptir. Optimum yanma performansı için Zippo Premium Bütan gazı kullanılması önerilir.", "../../images/cakmak/mum-icin-cakmak.jpg", "Çakmak", 180m, 6, 1, null },
                    { 7, 3, "Mavi", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6033), null, "Zippo'nun yepyeni Denim serisinin bir parçası. Cebinizde tarz yaratın! Orijinal Zippo logosuna ve ihtiyacınız olan her şeye uyacak çeşitli bölmelere sahip bir deri-denim Kredi Kartı Tutucu.\r\n\r\nDeri ve Denim Kot Kumaşından Üretilmiştir\r\nKot ve Ten Rengi\r\nYatay biçimli İki Katlı Kredi Kartı Cüzdanı", "../../images/cuzdan/cuzdan-mavi.jpg", "Cüzdan", 150m, 5, 1, null },
                    { 8, 3, "Siyah", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6034), null, "Zippo'nun yepyeni Saffiano serisinin bir parçası. Orijinal Zippo logosuna sahip, Saffiano kabartmalı ve çeşitli bölmelere sahip yüksek kaliteli deriden yapılmış bir deri cüzdan, ihtiyacınız olan her şeye uyacak şekilde.\r\n\r\nSafiano Deriden yapılmıştır\r\nYatay formatlı Fermuarlı Cüzdan\r\nBoyutlar: 9cm x 11cm x 2cm\r\nRFID özelliğine sahip\r\nSiyah", "../../images/cuzdan/cuzdan-siyah1.jpg", "Cüzdan", 120m, 5, 1, null },
                    { 9, 3, "Siyah", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6035), null, "Zippo'nun yepyeni Saffiano serisinin bir parçası. Orijinal Zippo logosuna sahip, Saffiano kabartmalı ve çeşitli bölmelere sahip yüksek kaliteli deriden yapılmış bir deri cüzdan, ihtiyacınız olan her şeye uyacak şekilde.\r\n\r\nSafiano Deriden yapılmıştır\r\nYatay biçim Üç bölmeli Cüzdan\r\nBoyutlar: 10,5cm x 9cm x 3,5cm\r\nRFID özelliğine sahip\r\nSiyah", "../../images/cuzdan/cuzdan-siyah2.jpg", "Cüzdan", 100m, 5, 1, null },
                    { 10, 3, "Siyah", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6037), null, "Renk: Yeşil.\r\nBoyutlar: 10,5 x 8 x 1 cm.\r\nHakiki Deri\r\n6 Kart, 2 İç göz,1 Kimlik gözü\r\nÇevre dostu bir hediye kutusunda paketlenmiştir. Zippo kalitesine uygun olarak Hindistan'da üretilmiştir.Renk: Yeşil.\r\nBoyutlar: 10,5 x 8 x 1 cm.\r\nHakiki Deri\r\n6 Kart, 2 İç göz,1 Kimlik gözü\r\nÇevre dostu bir hediye kutusunda paketlenmiştir. Zippo kalitesine uygun olarak Hindistan'da üretilmiştir.", "../../images/cuzdan/cuzdan-yesil.jpg", "Cüzdan", 100m, 5, 1, null },
                    { 11, 4, "Kırmızı", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6038), null, "G:55mm Y:44mm K:17mm\r\nPolikarbon alaşım\r\nOptik Sınıf: 1\r\n\r\nMaksimum UV koruması\r\n\r\nMikrofiber kılıf\r\nÜcretsiz yanında: Sert karton koruma kabı ve mikrofiber bezPolikarbon alaşım\r\nOptik Sınıf: 1\r\n\r\nMaksimum UV koruması", "../../images/gozluk/gozluk-kirmizi.jpg", "Gözlük", 150m, 5, 1, null },
                    { 12, 4, "Mavi", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6040), null, "G:58mm Y:50mm K:17mm\r\nMetal alaşım\r\nOptik Sınıf: 1\r\nMaksimum UV koruması\r\n\r\nMikrofiber kılıf\r\nÜcretsiz yanında: Sert karton koruma kabı ve mikrofiber bezMetal alaşım\r\nOptik Sınıf: 1\r\nMaksimum UV koruması", "../../images/gozluk/gozluk-mavi.jpg", "Gözlük", 150m, 5, 1, null },
                    { 13, 4, "Siyah", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6041), null, "G:58mm Y:50mm K:17mm\r\nÖn Genişlik: 138mm\r\nSap Uzunluğu: 140mm\r\nMetal alaşım\r\nOptik Sınıf: 1\r\nMaksimum UV korumasıMetal alaşım\r\nOptik Sınıf: 1\r\nMaksimum UV koruması", "../../images/gozluk/gozluk-siyah.jpg", "Gözlük", 150m, 5, 1, null },
                    { 14, 5, "Siyah", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6042), null, "Zippo'nun parlak siyah tükenmez kalemi (Ballpoint) çift yönlü açılabilme, Zippo logolu metal klipsli ve orta kalınlıkta siyah uç. Zippo'nun bu kalemi hediye edilmeye uygun özel doğa dostu karton kutusunda iki yıl garanti kapsamındadır.\r\n•Çift Yönlü Açılma\r\n•Tükenmez Kalem (Ball Point)\r\n•Özel doğa dostu karton kutusunda\r\n•Garanti", "../../images/kalem/kalem-siyah.jpg", "Kalem", 150m, 5, 1, null },
                    { 15, 5, "Mavi", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6044), null, "Zippo'nun gümüş rengi fırçalanmış görünümlü krom tükenmez kalemi (Ballpoint) pürüzsüz ve şık bir görünüm sunuyor. Çift yönlü açma ve kapama, Zippo logolu sabit metal klips ve orta kalınlıkta siyah uç. Zippo'nun gümüş rengi fırçalanmış krom tükenmez kalemi hediye edilmeye uygun özel doğa dostu karton kutusunda iki yıl garanti kapsamındadır.\r\n•Çift Yönlü Açılma\r\n•Tükenmez Kalem (Ball Point)\r\n•Özel doğa dostu karton kutusunda\r\n•Garanti", "../../images/kalem/kalem-mavi1.jpg", "Kalem", 150m, 5, 1, null },
                    { 16, 5, "Mavi", new DateTime(2024, 4, 14, 22, 2, 22, 346, DateTimeKind.Local).AddTicks(6045), null, "Zippo'nun gümüş rengi fırçalanmış görünümlü krom ince tükenmez kalemi (Rollerball) pürüzsüz ve şık bir görünüm sunuyor. Aç-kapa kapak özellikli Zippo logolu metal klips ve siyah ucuyla Zippo'nun bu kalemi hediye edilmeye uygun özel doğa dostu karton kutusunda iki yıl garanti kapsamındadır.\r\n•Aç-Kapa Kapak\r\n•İnce Tükenmez Kalem (Roller Ball)\r\n•Özel doğa dostu karton kutusunda\r\n•Garanti", "../../images/kalem/kalem-mavi2.jpg", "Kalem", 150m, 5, 1, null }
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
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductId",
                table: "ProductOrders",
                column: "ProductId");

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
                name: "Messages");

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
