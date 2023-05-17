using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelsinkiBikes.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    SwedishName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    SwedishAddress = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    SwedishCityName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    xAxel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yAxel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureStationId = table.Column<int>(type: "int", nullable: true),
                    DepartureStationName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    ReturnStationId = table.Column<int>(type: "int", nullable: true),
                    ReturnStationName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
