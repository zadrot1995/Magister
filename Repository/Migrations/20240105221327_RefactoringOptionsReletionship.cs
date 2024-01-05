using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringOptionsReletionship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Companies_CompanyId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Companies_CompanyId1",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Companies_CompanyId2",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "CompanyId2",
                table: "Options",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "CompanyId1",
                table: "Options",
                newName: "ManagementSystemId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Options",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Options_CompanyId2",
                table: "Options",
                newName: "IX_Options_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Options_CompanyId1",
                table: "Options",
                newName: "IX_Options_ManagementSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_Options_CompanyId",
                table: "Options",
                newName: "IX_Options_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Companies_CategoryId",
                table: "Options",
                column: "CategoryId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Companies_ManagementSystemId",
                table: "Options",
                column: "ManagementSystemId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Companies_TypeId",
                table: "Options",
                column: "TypeId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Companies_CategoryId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Companies_ManagementSystemId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Companies_TypeId",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Options",
                newName: "CompanyId2");

            migrationBuilder.RenameColumn(
                name: "ManagementSystemId",
                table: "Options",
                newName: "CompanyId1");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Options",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Options_TypeId",
                table: "Options",
                newName: "IX_Options_CompanyId2");

            migrationBuilder.RenameIndex(
                name: "IX_Options_ManagementSystemId",
                table: "Options",
                newName: "IX_Options_CompanyId1");

            migrationBuilder.RenameIndex(
                name: "IX_Options_CategoryId",
                table: "Options",
                newName: "IX_Options_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Companies_CompanyId",
                table: "Options",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Companies_CompanyId1",
                table: "Options",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Companies_CompanyId2",
                table: "Options",
                column: "CompanyId2",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
