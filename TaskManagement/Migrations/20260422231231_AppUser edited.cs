using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class AppUseredited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "252e78a8-e51f-46ce-a31f-980fdd144905");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eafe71e3-5dee-4781-8006-72ae98020f52");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fd89459-e79e-4e5f-845a-7683e4b6b61b", null, "user", "USER" },
                    { "7eccce96-04d7-4627-92a5-2ce63e0ed430", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fd89459-e79e-4e5f-845a-7683e4b6b61b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eccce96-04d7-4627-92a5-2ce63e0ed430");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "252e78a8-e51f-46ce-a31f-980fdd144905", null, "user", "USER" },
                    { "eafe71e3-5dee-4781-8006-72ae98020f52", null, "admin", "ADMIN" }
                });
        }
    }
}
