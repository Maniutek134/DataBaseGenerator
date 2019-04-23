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
                name: "WeatherCondition",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    temperature = table.Column<float>(nullable: false),
                    pressure = table.Column<float>(nullable: false),
                    humidity = table.Column<float>(nullable: false),
                    visibility = table.Column<int>(nullable: false),
                    windSpeed = table.Column<float>(nullable: false),
                    windDeg = table.Column<float>(nullable: false),
                    measureTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCondition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Intensity",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    roadSegmentId = table.Column<int>(nullable: false),
                    intenstiy = table.Column<float>(nullable: false),
                    measureTime = table.Column<DateTime>(nullable: false),
                    dbTemperatureid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intensity", x => x.id);
                    table.ForeignKey(
                        name: "FK_Intensity_WeatherCondition_dbTemperatureid",
                        column: x => x.dbTemperatureid,
                        principalTable: "WeatherCondition",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intensity_dbTemperatureid",
                table: "Intensity",
                column: "dbTemperatureid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intensity");

            migrationBuilder.DropTable(
                name: "WeatherCondition");
        }
    }
}
