using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infrastructure.Migrations
{
    public partial class initialCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 2, 0, 2, 334, DateTimeKind.Local).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 2, 0, 2, 334, DateTimeKind.Local).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 2, 0, 2, 334, DateTimeKind.Local).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 2, 0, 2, 334, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 2, 0, 2, 334, DateTimeKind.Local).AddTicks(5733));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 2, 0, 2, 334, DateTimeKind.Local).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 4, 3, 2, 0, 2, 334, DateTimeKind.Local).AddTicks(5736));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 2, 17, 37, 19, 737, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 2, 17, 37, 19, 737, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 2, 17, 37, 19, 737, DateTimeKind.Local).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 2, 17, 37, 19, 737, DateTimeKind.Local).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 4, 2, 17, 37, 19, 737, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 4, 2, 17, 37, 19, 737, DateTimeKind.Local).AddTicks(9934));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 4, 2, 17, 37, 19, 737, DateTimeKind.Local).AddTicks(9935));
        }
    }
}
