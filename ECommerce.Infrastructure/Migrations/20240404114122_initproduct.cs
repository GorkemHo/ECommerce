using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infrastructure.Migrations
{
    public partial class initproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7146), "Cüzdan" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "ImagePath", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7147), null, "Aksesuar", null, "Gözlük", 1, null },
                    { 5, new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7148), null, "Aksesuar", null, "Kalem", 1, null }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreateDate" },
                values: new object[] { 1, new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7252) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreateDate" },
                values: new object[] { 2, new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreateDate" },
                values: new object[] { 2, new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7256) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7257), "Cüzdan 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7260), "Cüzdan 2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "CreateDate", "DeleteDate", "Description", "ImagePath", "Name", "Price", "Quantity", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 8, 4, "Kırmızı", new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7262), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Gözlük 1", 150m, 5, 1, null },
                    { 9, 4, "Kırmızı", new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7263), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Gözlük 2", 150m, 5, 1, null },
                    { 10, 5, "Kırmızı", new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7264), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Kalem 1", 150m, 5, 1, null },
                    { 11, 5, "Kırmızı", new DateTime(2024, 4, 4, 14, 41, 22, 61, DateTimeKind.Local).AddTicks(7266), null, "Bu ürünün açıklaması 2", "images/Aksesuar2.jpg", "Kaelm 2", 150m, 5, 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5021), "Aksesuar" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreateDate" },
                values: new object[] { 2, new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreateDate" },
                values: new object[] { 1, new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5154) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreateDate" },
                values: new object[] { 1, new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5162), "Aksesuar 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5166), "Aksesuar 2" });
        }
    }
}
