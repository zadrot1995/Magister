using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringOptionsReletionship55555 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_OwnCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OwnCompanyId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OwnerId",
                table: "Companies",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_OwnerId",
                table: "Companies",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_OwnerId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_OwnerId",
                table: "Companies");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OwnCompanyId",
                table: "AspNetUsers",
                column: "OwnCompanyId",
                unique: true,
                filter: "[OwnCompanyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_OwnCompanyId",
                table: "AspNetUsers",
                column: "OwnCompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
