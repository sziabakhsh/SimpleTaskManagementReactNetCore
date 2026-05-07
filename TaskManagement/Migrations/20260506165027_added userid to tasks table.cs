using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class addeduseridtotaskstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0c9ffdd-84e4-40f9-a59c-37d6bb61f8c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3836966-6342-4fcf-b368-3c25a1dd5c12");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TaskItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e5b2063-ce54-4e86-9cea-f95159e42758", null, "user", "USER" },
                    { "65e242de-70bb-4c32-8e2e-f499501a102d", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e5b2063-ce54-4e86-9cea-f95159e42758");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65e242de-70bb-4c32-8e2e-f499501a102d");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0c9ffdd-84e4-40f9-a59c-37d6bb61f8c4", null, "admin", "ADMIN" },
                    { "e3836966-6342-4fcf-b368-3c25a1dd5c12", null, "user", "USER" }
                });
        }
    }
}
