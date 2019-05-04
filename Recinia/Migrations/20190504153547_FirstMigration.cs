using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recinia.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    PubID = table.Column<Guid>(nullable: false),
                    contenu = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    TimePost = table.Column<string>(nullable: true),
                    AspNetUsersId = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.PubID);
                    table.ForeignKey(
                        name: "FK_Publications_AspNetUsers_AspNetUsersId",
                        column: x => x.AspNetUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

           



            migrationBuilder.CreateIndex(
                name: "IX_Publications_AspNetUsersId",
                table: "Publications",
                column: "AspNetUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropTable(
                name: "Individual");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Adr",
                schema: "Adress");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
