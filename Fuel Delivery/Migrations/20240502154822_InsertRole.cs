using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fuel_Delivery.Migrations
{
    public partial class InsertRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "182284b9-dc62-4db3-9dc8-52e08998d161", "2266611d-6e36-465f-ab7c-2ebf041e79dc", "Driver", "Driver" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ad46018-4219-46fd-a599-0c664a6e79f5", "318e3d4b-6e89-4806-9aba-ba8e6b8ef860", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7ed4c94-f6fd-4ebe-aee1-4c5a625ae606", "d691bc50-f0f9-4204-8250-4f6aef7532e8", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "182284b9-dc62-4db3-9dc8-52e08998d161");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ad46018-4219-46fd-a599-0c664a6e79f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ed4c94-f6fd-4ebe-aee1-4c5a625ae606");
        }
    }
}
