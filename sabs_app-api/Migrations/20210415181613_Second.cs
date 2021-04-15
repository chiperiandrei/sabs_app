using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sabs_app_api.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { new Guid("f6099109-6bb6-45b2-8635-60df7f9164ad"), "emauik", "salut", "frate", "parola" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f6099109-6bb6-45b2-8635-60df7f9164ad"));
        }
    }
}
