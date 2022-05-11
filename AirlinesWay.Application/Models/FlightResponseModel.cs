namespace AirlinesWay.Application.Models;

public class FlightResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime ExpectedFinishDateTime { get; set; }
    public TimeSpan TimeDuration { get; set; }
    public decimal Price { get; set; }
    public string AirCompanyName { get; set; }

    public AirlineResponseModel AirlineResponse { get; set; }
}