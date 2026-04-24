using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class taskitemcolumnschanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64207b52-f557-4a3a-9e05-1ce6b85bd77b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75515f18-f170-483e-a987-b326a9d390e1");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "TaskItems");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TaskItems",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TaskItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0c9ffdd-84e4-40f9-a59c-37d6bb61f8c4", null, "admin", "ADMIN" },
                    { "e3836966-6342-4fcf-b368-3c25a1dd5c12", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0c9ffdd-84e4-40f9-a59c-37d6bb61f8c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3836966-6342-4fcf-b368-3c25a1dd5c12");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TaskItems");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TaskItems",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "TaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64207b52-f557-4a3a-9e05-1ce6b85bd77b", null, "user", "USER" },
                    { "75515f18-f170-483e-a987-b326a9d390e1", null, "admin", "ADMIN" }
                });
        }
    }
}
