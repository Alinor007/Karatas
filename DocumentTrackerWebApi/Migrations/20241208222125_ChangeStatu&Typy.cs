using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentTrackerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStatuTypy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "150bf7e0-dd67-42e4-b819-7d3c17ea36fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "672f2ff5-9308-409a-9e02-b86ba4b1a1d4");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32c59513-d23e-4b22-96df-4a7fae3a2708", null, "User", "USER" },
                    { "da70d9dc-e087-4198-a4b3-97bbb671ff51", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 22, 21, 24, 256, DateTimeKind.Utc).AddTicks(9167), new DateTime(2024, 12, 8, 22, 21, 24, 256, DateTimeKind.Utc).AddTicks(9170) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 22, 21, 24, 256, DateTimeKind.Utc).AddTicks(9173), new DateTime(2024, 12, 8, 22, 21, 24, 256, DateTimeKind.Utc).AddTicks(9174) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 22, 21, 24, 256, DateTimeKind.Utc).AddTicks(9175), new DateTime(2024, 12, 8, 22, 21, 24, 256, DateTimeKind.Utc).AddTicks(9176) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 22, 21, 24, 256, DateTimeKind.Utc).AddTicks(9177), new DateTime(2024, 12, 8, 22, 21, 24, 256, DateTimeKind.Utc).AddTicks(9177) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c59513-d23e-4b22-96df-4a7fae3a2708");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da70d9dc-e087-4198-a4b3-97bbb671ff51");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Documents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "150bf7e0-dd67-42e4-b819-7d3c17ea36fe", null, "Admin", "ADMIN" },
                    { "672f2ff5-9308-409a-9e02-b86ba4b1a1d4", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 6, 17, 13, 41, 796, DateTimeKind.Utc).AddTicks(3747), new DateTime(2024, 12, 6, 17, 13, 41, 796, DateTimeKind.Utc).AddTicks(3753) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 6, 17, 13, 41, 796, DateTimeKind.Utc).AddTicks(3763), new DateTime(2024, 12, 6, 17, 13, 41, 796, DateTimeKind.Utc).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 6, 17, 13, 41, 796, DateTimeKind.Utc).AddTicks(3767), new DateTime(2024, 12, 6, 17, 13, 41, 796, DateTimeKind.Utc).AddTicks(3768) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 6, 17, 13, 41, 796, DateTimeKind.Utc).AddTicks(3771), new DateTime(2024, 12, 6, 17, 13, 41, 796, DateTimeKind.Utc).AddTicks(3772) });
        }
    }
}
