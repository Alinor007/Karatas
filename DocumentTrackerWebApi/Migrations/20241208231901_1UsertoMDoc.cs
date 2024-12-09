using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentTrackerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class _1UsertoMDoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac2046d0-50f5-4a25-92cc-48b3fb3e8b47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc3d4191-6e09-43f4-91bc-0be8b66f9515");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94cb2a25-41ab-47fd-91a4-f64bf860f7f2", null, "User", "USER" },
                    { "eb493d67-dfce-4808-8c69-664f6d1bbf37", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 23, 19, 1, 200, DateTimeKind.Utc).AddTicks(7190), new DateTime(2024, 12, 8, 23, 19, 1, 200, DateTimeKind.Utc).AddTicks(7194) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 23, 19, 1, 200, DateTimeKind.Utc).AddTicks(7201), new DateTime(2024, 12, 8, 23, 19, 1, 200, DateTimeKind.Utc).AddTicks(7201) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 23, 19, 1, 200, DateTimeKind.Utc).AddTicks(7204), new DateTime(2024, 12, 8, 23, 19, 1, 200, DateTimeKind.Utc).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 12, 8, 23, 19, 1, 200, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 12, 8, 23, 19, 1, 200, DateTimeKind.Utc).AddTicks(7208) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94cb2a25-41ab-47fd-91a4-f64bf860f7f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb493d67-dfce-4808-8c69-664f6d1bbf37");

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
    }
}
