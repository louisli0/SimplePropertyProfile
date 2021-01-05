using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAPI.Migrations.GNAF
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GNAF_AddressData",
                columns: table => new
                {
                    AddressDetailId = table.Column<string>(nullable: false),
                    LocalityPID = table.Column<string>(nullable: true),
                    LotPrefix = table.Column<string>(nullable: true),
                    LotNumber = table.Column<string>(nullable: true),
                    LotSuffix = table.Column<string>(nullable: true),
                    FlatType = table.Column<string>(nullable: true),
                    FlatNumberPrefix = table.Column<string>(nullable: true),
                    FlatNumber = table.Column<int>(nullable: true),
                    FlatNumberSuffix = table.Column<string>(nullable: true),
                    LevelType = table.Column<string>(nullable: true),
                    LevelNumberPrefix = table.Column<string>(nullable: true),
                    LevelNumber = table.Column<int>(nullable: true),
                    LevelNumberSuffix = table.Column<string>(nullable: true),
                    NumberFirstPrefix = table.Column<string>(nullable: true),
                    NumberFirst = table.Column<int>(nullable: true),
                    NumberFirstSuffix = table.Column<string>(nullable: true),
                    NumberLastPrefix = table.Column<string>(nullable: true),
                    NumberLast = table.Column<int>(nullable: true),
                    NumberLastSuffix = table.Column<string>(nullable: true),
                    PostCode = table.Column<int>(nullable: true),
                    StreetLocalityPID = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(8, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GNAF_AddressData", x => x.AddressDetailId);
                });

            migrationBuilder.CreateTable(
                name: "GNAF_LocalityDetails",
                columns: table => new
                {
                    LocalityPID = table.Column<string>(nullable: false),
                    LocalityName = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(8, 6)", nullable: false),
                    PostCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GNAF_LocalityDetails", x => x.LocalityPID);
                });

            migrationBuilder.CreateTable(
                name: "GNAF_StreetLocalityDetails",
                columns: table => new
                {
                    StreetLocalityPid = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StreetType = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true),
                    LocalityPID = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(8, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GNAF_StreetLocalityDetails", x => x.StreetLocalityPid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GNAF_AddressData");

            migrationBuilder.DropTable(
                name: "GNAF_LocalityDetails");

            migrationBuilder.DropTable(
                name: "GNAF_StreetLocalityDetails");
        }
    }
}
