using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkIndustryAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkIndustry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkIndustry", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7730d731-f74b-4919-82f8-6f079f558986", "AQAAAAIAAYagAAAAEK0YnTBb7UEtBW/W4MkY164J5qKPxSunnuthtGfvpvLZgHTpDgKIYvy+cvmVvdlCyQ==", "c1d08f04-2039-401c-89ce-8182bc4fc9a2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkIndustry");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d173e91-6339-40e7-aede-c1273730211b", "AQAAAAIAAYagAAAAEAYadvNrcGkjHOrpFxY0F14dS451i8xsdYnfXssHJFJwqtI4Zt0TX8/5OgFR/E5BEA==", "037a6c1d-82bf-4674-9b5f-bda6bc1618d4" });
        }
    }
}
