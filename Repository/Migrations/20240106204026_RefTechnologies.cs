using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class RefTechnologies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Companies_CompanyId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_CompanyId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Technologies");

            migrationBuilder.CreateTable(
                name: "CompanyTechnology",
                columns: table => new
                {
                    CompaniesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnologiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTechnology", x => new { x.CompaniesId, x.TechnologiesId });
                    table.ForeignKey(
                        name: "FK_CompanyTechnology_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyTechnology_Technologies_TechnologiesId",
                        column: x => x.TechnologiesId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTechnology_TechnologiesId",
                table: "CompanyTechnology",
                column: "TechnologiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyTechnology");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Technologies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_CompanyId",
                table: "Technologies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Companies_CompanyId",
                table: "Technologies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
