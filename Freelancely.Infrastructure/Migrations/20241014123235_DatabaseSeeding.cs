using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Freelancely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2680690b-1683-45cb-8a99-cf0f9a9258aa", 0, "3e8bae71-654f-4aa1-ae05-1131860036df", "first@free.com", false, false, null, "first@free.com", "first@free.com", "AQAAAAIAAYagAAAAEOVietjRoGxJjHHuwl8xIaHp4VRwsZ6iaB5N6PaGHxBif3IAj7AGL6nGigP7FzJkGQ==", null, false, "874c6361-7b46-4615-b44b-dfd18c9f2699", false, "first@free.com" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Description", "PricePerHour", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "This is a test", 20m, "Test", "2680690b-1683-45cb-8a99-cf0f9a9258aa" },
                    { 2, "This is 2nd a test", 30m, "Test2", "2680690b-1683-45cb-8a99-cf0f9a9258aa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa");
        }
    }
}
