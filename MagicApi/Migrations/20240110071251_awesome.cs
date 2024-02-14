using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicApi.Migrations
{
    /// <inheritdoc />
    public partial class awesome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 10, 12, 42, 51, 277, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 10, 12, 42, 51, 277, DateTimeKind.Local).AddTicks(1692));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 8, 16, 35, 54, 719, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 8, 16, 35, 54, 719, DateTimeKind.Local).AddTicks(9679));
        }
    }
}
