using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Option_Companies_CompanyId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Companies_CompanyId1",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Companies_CompanyId2",
                table: "Option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                table: "Option");

            migrationBuilder.RenameTable(
                name: "Option",
                newName: "Options");

            migrationBuilder.RenameIndex(
                name: "IX_Option_CompanyId2",
                table: "Options",
                newName: "IX_Options_CompanyId2");

            migrationBuilder.RenameIndex(
                name: "IX_Option_CompanyId1",
                table: "Options",
                newName: "IX_Options_CompanyId1");

            migrationBuilder.RenameIndex(
                name: "IX_Option_CompanyId",
                table: "Options",
                newName: "IX_Options_CompanyId");

            migrationBuilder.AddColumn<int>(
                name: "OptionContext",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "OptionContext",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Option");

            migrationBuilder.RenameIndex(
                name: "IX_Options_CompanyId2",
                table: "Option",
                newName: "IX_Option_CompanyId2");

            migrationBuilder.RenameIndex(
                name: "IX_Options_CompanyId1",
                table: "Option",
                newName: "IX_Option_CompanyId1");

            migrationBuilder.RenameIndex(
                name: "IX_Options_CompanyId",
                table: "Option",
                newName: "IX_Option_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                table: "Option",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Companies_CompanyId",
                table: "Option",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Companies_CompanyId1",
                table: "Option",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Companies_CompanyId2",
                table: "Option",
                column: "CompanyId2",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
