namespace AirlinesWay.Domain;

public class Flight
{
    public Flight(string name, string code, DateTime startDateTime, DateTime expectedFinishDateTime, decimal price,
        int airlineId, DateTime timeDuration)
    {
        Name = name;
        Code = code;
        StartDateTime = startDateTime;
        ExpectedFinishDateTime = expectedFinishDateTime;
        Price = price;
        AirlineId = airlineId;
        TimeDuration = timeDuration;
    }

    public int Id { get; }
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime ExpectedFinishDateTime { get; set; }
    public DateTime TimeDuration { get; set; }
    public decimal Price { get; set; }

    public int AirlineId { get; set; }
    public Airline Airline { get; set; }
}