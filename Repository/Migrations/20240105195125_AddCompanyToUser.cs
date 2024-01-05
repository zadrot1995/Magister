using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_OwnerId1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_OwnerId1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Companies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OwnerId1",
                table: "Companies",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_OwnerId1",
                table: "Companies",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
