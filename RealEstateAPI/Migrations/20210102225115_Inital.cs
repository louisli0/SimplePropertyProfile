using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAPI.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NSWVGDatas",
                columns: table => new
                {
                    DealingNumber = table.Column<string>(nullable: true),
                    DistrictCode = table.Column<int>(nullable: false),
                    PropertyId = table.Column<string>(nullable: true),
                    UnitNumber = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    Locality = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    AreaType = table.Column<string>(nullable: true),
                    SettlementData = table.Column<DateTime>(nullable: false),
                    price = table.Column<string>(nullable: true),
                    NatureOfProperty = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    Strata = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NSWVGDatas");
        }
    }
}
