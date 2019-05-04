using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recinia.Migrations
{
    public partial class PiPMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumns: new[] { "ID", "Numéro" },
                keyValues: new object[] { 1, "123654" });

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumns: new[] { "ID", "Numéro" },
                keyValues: new object[] { 2, "789654" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "ID", "Numéro", "FirstName", "LastName" },
                values: new object[] { 1, "123654", "Omar", "Karmous" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "ID", "Numéro", "FirstName", "LastName" },
                values: new object[] { 2, "789654", "Mario", "brutti" });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PubID", "AspNetUserId", "AspNetUsersId", "Image", "contenu" },
                values: new object[] { new Guid("ca6e58be-0470-4053-89d3-8b3d9e1d01e5"), "9c879b33-b99d-4456-ad2b-c362f6fc858a", null, "qqsdfghbjnkjnkj", "Préparation" });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PubID", "AspNetUserId", "AspNetUsersId", "Image", "contenu" },
                values: new object[] { new Guid("114d2b8c-4169-4d4e-afdd-bd4fe9b8f2c9"), "9c879b33-b99d-4456-ad2b-c362f6fc858a", null, "Pomme", "Fiche Technique" });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PubID", "AspNetUserId", "AspNetUsersId", "Image", "contenu" },
                values: new object[] { new Guid("2183ef60-9ce1-4b16-bb88-f5b99987349e"), "9c879b33-b99d-4456-ad2b-c362f6fc858a", null, "azertyuicvb", "Védio" });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PubID", "AspNetUserId", "AspNetUsersId", "Image", "contenu" },
                values: new object[] { new Guid("91f899c1-ae8d-4ab6-8512-9bc2ee2ec4d7"), "9c879b33-b99d-4456-ad2b-c362f6fc858a", null, "5222222222222", "Image" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumns: new[] { "ID", "Numéro" },
                keyValues: new object[] { 1, "123654" });

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumns: new[] { "ID", "Numéro" },
                keyValues: new object[] { 2, "789654" });

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PubID",
                keyValue: new Guid("114d2b8c-4169-4d4e-afdd-bd4fe9b8f2c9"));

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PubID",
                keyValue: new Guid("2183ef60-9ce1-4b16-bb88-f5b99987349e"));

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PubID",
                keyValue: new Guid("91f899c1-ae8d-4ab6-8512-9bc2ee2ec4d7"));

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PubID",
                keyValue: new Guid("ca6e58be-0470-4053-89d3-8b3d9e1d01e5"));

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "ID", "Numéro", "FirstName", "LastName" },
                values: new object[] { 1, "123654", "Omar", "Karmous" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "ID", "Numéro", "FirstName", "LastName" },
                values: new object[] { 2, "789654", "Mario", "brutti" });
        }
    }
}
