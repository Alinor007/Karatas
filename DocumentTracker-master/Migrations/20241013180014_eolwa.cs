using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentTrackerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class eolwa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a95b908-5408-436f-8eab-70a75a73d802");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15c4dddb-720d-4c91-a66d-40f59e7566b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "134eb5a2-5cd6-4441-9770-fa085c576d25", null, "IdentityRole", "User", "USER" },
                    { "a90b203c-b28b-418d-9222-61c3691921a8", null, "IdentityRole", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134eb5a2-5cd6-4441-9770-fa085c576d25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a90b203c-b28b-418d-9222-61c3691921a8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a95b908-5408-436f-8eab-70a75a73d802", null, "IdentityRole", "Admin", "ADMIN" },
                    { "15c4dddb-720d-4c91-a66d-40f59e7566b4", null, "IdentityRole", "User", "USER" }
                });
        }
    }
}
