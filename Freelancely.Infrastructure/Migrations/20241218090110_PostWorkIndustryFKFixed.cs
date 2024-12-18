using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PostWorkIndustryFKFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WorkIndustryId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffc26cd7-9c24-47e3-9cb1-0c32eb4b013c", "AQAAAAIAAYagAAAAEPo2RRfyOCgGvMfJ6SEY9xxJ7oqYFqQdmDzyWYz9N6jHOaqq0i+lfDeS8QlGgHtWDA==", "bc527dcb-b187-432e-bd2e-875099caaa25" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WorkIndustryId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbe9f84c-710f-4652-b04f-bd5a8e0b61b3", "AQAAAAIAAYagAAAAEOHx10J+c/9vmK+gZFkSj33PU6iLg29BEtke8QjjAMtUBrDEYdsqxzydFdNjufyAtg==", "b82f1afe-eeec-40ba-ba5d-bd6bb617213a" });
        }
    }
}
