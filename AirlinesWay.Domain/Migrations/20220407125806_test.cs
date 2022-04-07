using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlinesWay.Domain.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirCompanyId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirCompanyId",
                table: "Flights",
                column: "AirCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_AirCompanies_AirCompanyId",
                table: "Flights",
                column: "AirCompanyId",
                principalTable: "AirCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_AirCompanies_AirCompanyId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirCompanyId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirCompanyId",
                table: "Flights");
        }
    }
}
