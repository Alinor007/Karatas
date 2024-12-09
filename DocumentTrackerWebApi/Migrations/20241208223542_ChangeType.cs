using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentTrackerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c59513-d23e-4b22-96df-4a7fae3a2708");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da70d9dc-e087-4198-a4b3-97bbb671ff51");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
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
                    { "ac2046d0-50f5-4a25-92cc-48b3fb3e8b47", null, "Admin", "ADMIN" },
                    { "bc3d4191-6e09-43f4-91bc-0be8b66f9515", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 22, 35, 41, 869, DateTimeKind.Utc).AddTicks(6840), new DateTime(2024, 12, 8, 22, 35, 41, 869, DateTimeKind.Utc).AddTicks(6843) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 22, 35, 41, 869, DateTimeKind.Utc).AddTicks(6846), new DateTime(2024, 12, 8, 22, 35, 41, 869, DateTimeKind.Utc).AddTicks(6847) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 22, 35, 41, 869, DateTimeKind.Utc).AddTicks(6848), new DateTime(2024, 12, 8, 22, 35, 41, 869, DateTimeKind.Utc).AddTicks(6848) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 22, 35, 41, 869, DateTimeKind.Utc).AddTicks(6849), new DateTime(2024, 12, 8, 22, 35, 41, 869, DateTimeKind.Utc).AddTicks(6849) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac2046d0-50f5-4a25-92cc-48b3fb3e8b47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc3d4191-6e09-43f4-91bc-0be8b66f9515");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
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
    }
}
