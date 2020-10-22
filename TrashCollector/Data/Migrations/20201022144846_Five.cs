using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6490a00b-1b0a-4629-80c6-f6d7485c17e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da6a9165-b38f-4a34-8894-a65241a2245b");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ConfirmPickUp",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aef716a3-ec93-4d20-a007-f690a7afb74b", "23060788-d912-4f87-83b5-83c60cd8421f", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82f6e749-208a-4466-922e-eb137d74ea6d", "92704feb-e782-4158-a394-b6992735b2af", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdentityUserId",
                table: "Employee",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_IdentityUserId",
                table: "Employee",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_IdentityUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_IdentityUserId",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82f6e749-208a-4466-922e-eb137d74ea6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef716a3-ec93-4d20-a007-f690a7afb74b");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ConfirmPickUp",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da6a9165-b38f-4a34-8894-a65241a2245b", "8ff58844-9458-498b-8b45-48e28d04fed4", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6490a00b-1b0a-4629-80c6-f6d7485c17e2", "bd306377-8d7f-4db9-bd4d-5fcd12a39e15", "Employee", "EMPLOYEE" });
        }
    }
}
