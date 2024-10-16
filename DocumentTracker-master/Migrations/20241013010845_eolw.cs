using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentTrackerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class eolw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "267440c7-e777-45ea-8e27-2961f127766e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a415ed89-eeb6-4e03-b9bc-9a28e2df4918");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a95b908-5408-436f-8eab-70a75a73d802", null, "IdentityRole", "Admin", "ADMIN" },
                    { "15c4dddb-720d-4c91-a66d-40f59e7566b4", null, "IdentityRole", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "267440c7-e777-45ea-8e27-2961f127766e", null, "IdentityRole", "User", "USER" },
                    { "a415ed89-eeb6-4e03-b9bc-9a28e2df4918", null, "IdentityRole", "Admin", "ADMIN" }
                });
        }
    }
}
