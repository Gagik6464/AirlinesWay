namespace AirlinesWay.Domain;

public class AirCompany
{
    public AirCompany(string name)
    {
        Name = name;
    }
    public int Id { get;}
    public string Name { get; set; }
    public IEnumerable<Airline> Airlines { get; set; }
}