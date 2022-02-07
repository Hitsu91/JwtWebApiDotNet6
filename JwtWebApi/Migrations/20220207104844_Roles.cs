using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtWebApi.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("be349114-0d0b-4f09-8c70-9443d36b405c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("d28c1ddd-6240-41a8-8d81-73c3e57b94af"));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { new Guid("1c3c9a4e-704d-487a-95c3-45b943b9928f"), 300, "Fireball" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { new Guid("87b0b23e-1de2-4298-902e-c5672f855390"), 20, "Frenzy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("9bb84b92-60c9-4375-a08a-c1d46935f573"), new byte[] { 216, 200, 183, 194, 215, 157, 177, 76, 99, 163, 137, 41, 230, 227, 156, 48, 97, 201, 32, 240, 192, 83, 29, 219, 184, 165, 143, 129, 11, 132, 177, 174, 30, 39, 2, 36, 154, 130, 55, 58, 61, 103, 229, 107, 201, 9, 130, 141, 27, 198, 91, 215, 123, 158, 154, 199, 50, 251, 84, 29, 134, 155, 92, 157 }, new byte[] { 171, 186, 103, 104, 136, 6, 210, 197, 157, 162, 137, 65, 191, 60, 47, 228, 167, 115, 221, 222, 242, 111, 188, 60, 63, 113, 42, 2, 99, 14, 125, 92, 133, 164, 41, 58, 150, 135, 57, 88, 82, 187, 181, 6, 246, 178, 74, 22, 254, 183, 48, 134, 6, 190, 118, 249, 207, 221, 46, 219, 171, 68, 184, 180, 98, 99, 70, 234, 34, 160, 207, 227, 242, 97, 170, 61, 205, 231, 68, 39, 133, 166, 176, 81, 36, 134, 93, 175, 193, 51, 223, 177, 200, 222, 54, 160, 211, 184, 57, 133, 234, 250, 246, 59, 60, 151, 123, 45, 172, 82, 8, 139, 199, 4, 120, 185, 166, 212, 17, 181, 250, 74, 131, 165, 21, 200, 154, 250 }, 1, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("1c3c9a4e-704d-487a-95c3-45b943b9928f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("87b0b23e-1de2-4298-902e-c5672f855390"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9bb84b92-60c9-4375-a08a-c1d46935f573"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { new Guid("be349114-0d0b-4f09-8c70-9443d36b405c"), 300, "Fireball" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { new Guid("d28c1ddd-6240-41a8-8d81-73c3e57b94af"), 20, "Frenzy" });
        }
    }
}
