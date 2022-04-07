namespace AirlinesWay.Application.Models;

public class AirlineResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Distance { get; set; }

    public int StartedCityId { get; set; }
    public string StartedCityName { get; set; }
    
    public int? IntermediateCityId { get; set; }
    public string? IntermediateCityName { get; set; }
    
    public int FinishedCityId { get; set; }
    public string FinishedCityName { get; set; }

    public string AirCompanyName { get; set; }

    public int CurrentlyFlightCount { get; set; }
}