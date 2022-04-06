namespace AirlinesWay.Domain;

public class City
{
    public City(string name, int countryId, Country country)
    {
        Name = name;
        Country = country;
    }
    
    public int Id { get; }
    public string Name { get; set; }
    
    
    public int CountryId { get; set; }
    public Country Country { get; set; }
}