using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fuel_Delivery.Migrations
{
    public partial class AddFuelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85a7b648-4abd-47e5-ba9f-70751d247fd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f496de8-7615-4f71-97fc-ffc0826962c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3895362-fa97-4bfa-a541-a00d2cae8f32");

            migrationBuilder.CreateTable(
                name: "Fuel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "191d0d8e-5d6d-4e5d-8452-cef74ad8e639", "31d96522-7541-438b-a336-cdca5fdf522e", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a0e8e4f-62cf-4a5d-b812-9dc64cac0482", "539cff54-55f2-4949-aaf4-38d38e9bc4e0", "Driver", "Driver" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed7b2591-2ecb-4bf4-993e-4d7071fa1818", "548b85f9-8758-4254-911c-2890e1b790aa", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "191d0d8e-5d6d-4e5d-8452-cef74ad8e639");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a0e8e4f-62cf-4a5d-b812-9dc64cac0482");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed7b2591-2ecb-4bf4-993e-4d7071fa1818");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85a7b648-4abd-47e5-ba9f-70751d247fd3", "c8e906ef-bbef-4c94-8103-072ea230ca32", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f496de8-7615-4f71-97fc-ffc0826962c6", "1627a5f6-0674-4484-bf45-831323b9821a", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3895362-fa97-4bfa-a541-a00d2cae8f32", "70978478-2fb6-4228-a55c-e835257f2726", "Driver", "Driver" });
        }
    }
}
