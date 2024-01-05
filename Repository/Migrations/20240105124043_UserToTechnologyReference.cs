using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UserToTechnologyReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_AspNetUsers_UserId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_UserId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Technologies");

            migrationBuilder.CreateTable(
                name: "TechnologyUser",
                columns: table => new
                {
                    UserSkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyUser", x => new { x.UserSkillsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TechnologyUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnologyUser_Technologies_UserSkillsId",
                        column: x => x.UserSkillsId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnologyUser_UsersId",
                table: "TechnologyUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnologyUser");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Technologies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_UserId",
                table: "Technologies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_AspNetUsers_UserId",
                table: "Technologies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
