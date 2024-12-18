using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancely.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserColumsAndReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationType = table.Column<int>(type: "int", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    WriterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c51c229-c4a1-49c7-be15-77f611964c11", "AQAAAAIAAYagAAAAEA65ytyz0KnWgbXSBYUEYS74IuWyzIOOEdvPkj3tTEEnTfdF9cydXz9HDZYlnlAG0w==", "3ae52f66-db91-4ed3-bfae-550a0f8cd57a" });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UserId",
                table: "Educations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecipientId",
                table: "Reviews",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_WriterId",
                table: "Reviews",
                column: "WriterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffc26cd7-9c24-47e3-9cb1-0c32eb4b013c", "AQAAAAIAAYagAAAAEPo2RRfyOCgGvMfJ6SEY9xxJ7oqYFqQdmDzyWYz9N6jHOaqq0i+lfDeS8QlGgHtWDA==", "bc527dcb-b187-432e-bd2e-875099caaa25" });
        }
    }
}
