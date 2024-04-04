using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infrastructure.Migrations
{
    public partial class initdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ImagePath" },
                values: new object[] { new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1635), "images/00285a53-201b-475e-b056-31b524c0354c.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "ImagePath" },
                values: new object[] { new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1637), "images/00ca64ae-faaa-4235-bd98-a4bb4623bfc2.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1646), "Bu ürünün açıklaması 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 11, 26, 57, 456, DateTimeKind.Local).AddTicks(1648));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "CartItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ImagePath" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8194), "images/cakmak1.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "ImagePath" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8197), "images/cakmak2.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8202), "Bu ürünün açıklaması 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 11, 45, 8, 459, DateTimeKind.Local).AddTicks(8203));
        }
    }
}
