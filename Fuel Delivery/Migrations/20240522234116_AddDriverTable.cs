using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fuel_Delivery.Migrations
{
    public partial class AddDriverTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Diver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diver", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diver");

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
    }
}
