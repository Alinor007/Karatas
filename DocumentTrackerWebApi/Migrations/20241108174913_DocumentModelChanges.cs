using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentTrackerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class DocumentModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39607333-a692-4472-a948-31d55b9a6ca4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc377f5e-3266-4db4-a355-066364ddadbe");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Documents",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "Documents",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Documents",
                newName: "TrackingNumber");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Documents",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Documents",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07ffe708-34b5-4796-8ec3-cd1912847499", null, "User", "USER" },
                    { "63af6246-ffcc-4656-9872-3d8e2a844579", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 49, 12, 250, DateTimeKind.Utc).AddTicks(2388), new DateTime(2024, 11, 8, 17, 49, 12, 250, DateTimeKind.Utc).AddTicks(2391) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 49, 12, 250, DateTimeKind.Utc).AddTicks(2395), new DateTime(2024, 11, 8, 17, 49, 12, 250, DateTimeKind.Utc).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 49, 12, 250, DateTimeKind.Utc).AddTicks(2396), new DateTime(2024, 11, 8, 17, 49, 12, 250, DateTimeKind.Utc).AddTicks(2396) });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 49, 12, 250, DateTimeKind.Utc).AddTicks(2398), new DateTime(2024, 11, 8, 17, 49, 12, 250, DateTimeKind.Utc).AddTicks(2398) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07ffe708-34b5-4796-8ec3-cd1912847499");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63af6246-ffcc-4656-9872-3d8e2a844579");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Documents",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "TrackingNumber",
                table: "Documents",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Documents",
                newName: "Updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Documents",
                newName: "Created");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Documents",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
