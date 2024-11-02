using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentTrackerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class dbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1961da14-8524-43b9-a55a-3a268da968df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc45742-ee39-44e9-95ec-63891246a607");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39607333-a692-4472-a948-31d55b9a6ca4", null, "Admin", "ADMIN" },
                    { "bc377f5e-3266-4db4-a355-066364ddadbe", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 2, 4, 15, 1, 783, DateTimeKind.Utc).AddTicks(314), new DateTime(2024, 11, 2, 4, 15, 1, 783, DateTimeKind.Utc).AddTicks(317) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 2, 4, 15, 1, 783, DateTimeKind.Utc).AddTicks(321), new DateTime(2024, 11, 2, 4, 15, 1, 783, DateTimeKind.Utc).AddTicks(322) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 2, 4, 15, 1, 783, DateTimeKind.Utc).AddTicks(324), new DateTime(2024, 11, 2, 4, 15, 1, 783, DateTimeKind.Utc).AddTicks(324) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 2, 4, 15, 1, 783, DateTimeKind.Utc).AddTicks(326), new DateTime(2024, 11, 2, 4, 15, 1, 783, DateTimeKind.Utc).AddTicks(326) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39607333-a692-4472-a948-31d55b9a6ca4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc377f5e-3266-4db4-a355-066364ddadbe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1961da14-8524-43b9-a55a-3a268da968df", null, "Admin", "ADMIN" },
                    { "4cc45742-ee39-44e9-95ec-63891246a607", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 1, 13, 20, 9, 346, DateTimeKind.Utc).AddTicks(3647), new DateTime(2024, 11, 1, 13, 20, 9, 346, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 1, 13, 20, 9, 346, DateTimeKind.Utc).AddTicks(3654), new DateTime(2024, 11, 1, 13, 20, 9, 346, DateTimeKind.Utc).AddTicks(3654) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 1, 13, 20, 9, 346, DateTimeKind.Utc).AddTicks(3655), new DateTime(2024, 11, 1, 13, 20, 9, 346, DateTimeKind.Utc).AddTicks(3656) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 1, 13, 20, 9, 346, DateTimeKind.Utc).AddTicks(3657), new DateTime(2024, 11, 1, 13, 20, 9, 346, DateTimeKind.Utc).AddTicks(3657) });
        }
    }
}
