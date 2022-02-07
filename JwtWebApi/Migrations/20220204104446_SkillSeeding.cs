using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtWebApi.Migrations
{
    public partial class SkillSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { new Guid("be349114-0d0b-4f09-8c70-9443d36b405c"), 300, "Fireball" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { new Guid("d28c1ddd-6240-41a8-8d81-73c3e57b94af"), 20, "Frenzy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("be349114-0d0b-4f09-8c70-9443d36b405c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("d28c1ddd-6240-41a8-8d81-73c3e57b94af"));
        }
    }
}
