using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PostPricePerHourPrecisionFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerHour",
                table: "Posts",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d173e91-6339-40e7-aede-c1273730211b", "AQAAAAIAAYagAAAAEAYadvNrcGkjHOrpFxY0F14dS451i8xsdYnfXssHJFJwqtI4Zt0TX8/5OgFR/E5BEA==", "037a6c1d-82bf-4674-9b5f-bda6bc1618d4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerHour",
                table: "Posts",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02b33224-d0b2-4622-bfa6-79352f26565e", "AQAAAAIAAYagAAAAEHOgaW/MF/mKL0H5Hj+x5tRSTpCB8Sfr/M01shlMS4vXrRtfU0I9HyJ8Dm87KjnwAw==", "e2dd4617-e764-4366-b6a6-80f6c602dadf" });
        }
    }
}
