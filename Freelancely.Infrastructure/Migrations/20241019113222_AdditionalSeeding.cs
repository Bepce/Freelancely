using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7b010aa-36ed-415e-9e20-73c4dfc4ff2a", "AQAAAAIAAYagAAAAENfMZ/fo5nKd24ZsUKu2ClePTeTUdnk4FJpn2pH1Wvwyy3gwQYmMFpqfZOWVrwuM0A==", "1090f01e-bb00-4e1d-8e25-158a3f237c2e" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Description", "PricePerHour", "Title", "UserId" },
                values: new object[] { 3, "Photographer looking for work in Sofia, Bulgaria", 50m, "Photographer", "2680690b-1683-45cb-8a99-cf0f9a9258aa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e8bae71-654f-4aa1-ae05-1131860036df", "AQAAAAIAAYagAAAAEOVietjRoGxJjHHuwl8xIaHp4VRwsZ6iaB5N6PaGHxBif3IAj7AGL6nGigP7FzJkGQ==", "874c6361-7b46-4615-b44b-dfd18c9f2699" });
        }
    }
}
