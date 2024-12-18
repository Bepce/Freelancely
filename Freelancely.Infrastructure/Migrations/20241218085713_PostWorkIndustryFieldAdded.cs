using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PostWorkIndustryFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WorkIndustry",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WorkIndustry",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PostCreationDate",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkIndustryId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbe9f84c-710f-4652-b04f-bd5a8e0b61b3", "AQAAAAIAAYagAAAAEOHx10J+c/9vmK+gZFkSj33PU6iLg29BEtke8QjjAMtUBrDEYdsqxzydFdNjufyAtg==", "b82f1afe-eeec-40ba-ba5d-bd6bb617213a" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PostCreationDate", "WorkIndustryId" },
                values: new object[] { "20/09/2024 08:10:02", 1 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PostCreationDate", "WorkIndustryId" },
                values: new object[] { "05/10/2024 16:32:08", 1 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PostCreationDate", "WorkIndustryId" },
                values: new object[] { "08/01/2024 13:03:43", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WorkIndustryId",
                table: "Posts",
                column: "WorkIndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_WorkIndustry_WorkIndustryId",
                table: "Posts",
                column: "WorkIndustryId",
                principalTable: "WorkIndustry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_WorkIndustry_WorkIndustryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_WorkIndustryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostCreationDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "WorkIndustryId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WorkIndustry",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WorkIndustry",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7730d731-f74b-4919-82f8-6f079f558986", "AQAAAAIAAYagAAAAEK0YnTBb7UEtBW/W4MkY164J5qKPxSunnuthtGfvpvLZgHTpDgKIYvy+cvmVvdlCyQ==", "c1d08f04-2039-401c-89ce-8182bc4fc9a2" });
        }
    }
}
