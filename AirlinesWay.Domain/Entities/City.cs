namespace AirlinesWay.Domain;

public class City
{
    public City(string name, int countryId)
    {
        Name = name;
        CountryId = countryId;
    }
    
    public int Id { get; }
    public string Name { get; set; }
    
    
    public int CountryId { get; set; }
    public Country Country { get; set; }

    public ICollection<Airline> Airlines { get; set; }
}