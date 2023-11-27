using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASPNet.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationseedingRegionandDifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06c543cc-35ef-44ce-b07f-f51b67f9c268"), "Easy" },
                    { new Guid("9f96adeb-d150-4105-8dc1-07bf5693b397"), "Hard" },
                    { new Guid("c90f9516-7255-42ae-8071-8b8612125fff"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("77a2669d-a009-495a-a413-a831f1538cd1"), "UDI", "Uberlândia", "www.imageofuberlândia.com.br" },
                    { new Guid("d619892d-510f-4b7e-ba65-5de7ae9ec419"), "ITB", "Ituiutaba", "wwww.imageofituiutaba.com.br" },
                    { new Guid("d740e5d9-6367-43ac-9031-4a3c0e5ab51b"), "UBA", "Uberaba", "www.imageofuberaba.com.br" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("06c543cc-35ef-44ce-b07f-f51b67f9c268"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9f96adeb-d150-4105-8dc1-07bf5693b397"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c90f9516-7255-42ae-8071-8b8612125fff"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("77a2669d-a009-495a-a413-a831f1538cd1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d619892d-510f-4b7e-ba65-5de7ae9ec419"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d740e5d9-6367-43ac-9031-4a3c0e5ab51b"));
        }
    }
}
