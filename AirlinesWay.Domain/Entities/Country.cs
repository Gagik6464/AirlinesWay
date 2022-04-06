namespace AirlinesWay.Domain;

public class Country
{
    public Country(string name, string code)
    {
        Name = name;
        Code = code;
    }
    
    public int Id { get;}
    public string Name { get; set; }
    public string Code { get; }

    public ICollection<City> Cities { get; set; }
}