using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infrastructure.Migrations
{
    public partial class initimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ImagePath" },
                values: new object[] { new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5148), "../../images/00285a53-201b-475e-b056-31b524c0354c.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "ImagePath" },
                values: new object[] { new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5152), "../../images/00ca64ae-faaa-4235-bd98-a4bb4623bfc2.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5154));

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
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 13, 27, 1, 226, DateTimeKind.Local).AddTicks(5166));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ImagePath" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3157), "images/00285a53-201b-475e-b056-31b524c0354c.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "ImagePath" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3159), "images/00ca64ae-faaa-4235-bd98-a4bb4623bfc2.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3164));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 4, 4, 12, 47, 12, 469, DateTimeKind.Local).AddTicks(3166));
        }
    }
}
