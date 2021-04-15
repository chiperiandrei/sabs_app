using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sabs_app_api.Migrations
{
    public partial class PublisherAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IPs_Users_UserForeignKey",
                table: "IPs");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f6099109-6bb6-45b2-8635-60df7f9164ad"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserForeignKey",
                table: "IPs",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "IPid",
                table: "IPs",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_IPs_UserForeignKey",
                table: "IPs",
                newName: "IX_IPs_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_IPs_Users_UserID",
                table: "IPs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IPs_Users_UserID",
                table: "IPs");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "IPs",
                newName: "UserForeignKey");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "IPs",
                newName: "IPid");

            migrationBuilder.RenameIndex(
                name: "IX_IPs_UserID",
                table: "IPs",
                newName: "IX_IPs_UserForeignKey");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { new Guid("f6099109-6bb6-45b2-8635-60df7f9164ad"), "emauik", "salut", "frate", "parola" });

            migrationBuilder.AddForeignKey(
                name: "FK_IPs_Users_UserForeignKey",
                table: "IPs",
                column: "UserForeignKey",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
