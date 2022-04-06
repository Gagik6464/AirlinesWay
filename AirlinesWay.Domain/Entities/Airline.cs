namespace AirlinesWay.Domain;

public class Airline
{
    public Airline(string name, int startedCityId, int finishedCityId)
    {
        Name = name;
        StartedCityId = startedCityId;
        FinishedCityId = finishedCityId;
    }

    public int Id { get; }
    public string Name { get; set; }
    public int Distance { get; set; }

    public int StartedCityId { get; set; }
    public City StartedCity { get; set; }
    
    public int? IntermediateCityId { get; set; }
    public City? IntermediateCity { get; set; }

    public int FinishedCityId { get; set; }
    public City FinishedCity { get; set; }

    public ICollection<AirCompany> AirCompanies { get; set; }
    public ICollection<Flight> Flights { get; set; }
}