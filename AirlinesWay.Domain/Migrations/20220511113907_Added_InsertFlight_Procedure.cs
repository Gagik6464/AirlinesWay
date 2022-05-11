using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlinesWay.Domain.Migrations
{
    public partial class Added_InsertFlight_Procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[sp_InsertFlightInfo]
    @Name nvarchar(50),
    @Code nvarchar(50),
    @StartDateTime datetime,
    @ExpectedFinishDateTime datetime,
    @TimeDuration time,
    @Price decimal(15,8),
    @AirCompanyId int,
	@AirlineId int
AS
BEGIN
        INSERT INTO [AirlinesWay].[dbo].[Flights]([Name],[Code],[StartDateTime],[ExpectedFinishDateTime], [TimeDuration], [Price], [AirCompanyId], [AirlineId])
        VALUES(@Name, @Code, @StartDateTime, @ExpectedFinishDateTime, @TimeDuration, @Price, @AirCompanyId, @AirlineId)
END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
