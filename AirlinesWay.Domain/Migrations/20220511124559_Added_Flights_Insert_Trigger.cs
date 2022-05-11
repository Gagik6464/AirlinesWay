using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlinesWay.Domain.Migrations
{
    public partial class Added_Flights_Insert_Trigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var trigger = @"CREATE TRIGGER Flights_INSERT
            ON Flights
            AFTER INSERT
            AS
            Update [Flights] set [ExpectedFinishDateTime] = 
            CAST((CAST(StartDateTime AS datetime) + CAST([TimeDuration] AS datetime)) AS datetime2)
            where Id in (Select [Id] From INSERTED)";

            migrationBuilder.Sql(trigger);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
