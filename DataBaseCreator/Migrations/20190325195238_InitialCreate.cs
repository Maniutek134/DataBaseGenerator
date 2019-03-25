using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseCreator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    airTemperature = table.Column<float>(nullable: false),
                    surfaceTemperature = table.Column<float>(nullable: false),
                    chemicalConcentration = table.Column<float>(nullable: false),
                    visibility = table.Column<float>(nullable: false),
                    waterIceThickness = table.Column<float>(nullable: false),
                    windSpeed = table.Column<float>(nullable: false),
                    measureTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temp");
        }
    }
}
