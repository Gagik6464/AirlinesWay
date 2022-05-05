namespace AirlinesWay.Domain.DbContext;

public static class DbInitializer
{
    public static void Initialize(AirlinesWayDbContext context)
    {
        context.Database.EnsureCreated();

        // Look for any students.
        if (context.Cities.Any())
        {
            return; // DB has been seeded
        }

        var countries = new Country[]
        {
            new("Armenia", "AM"),
            new("Australia", "AU"),
            new("Belarus", "BY"),
            new("India", "IN"),
            new("Iraq", "IQ"),
            new("Japan", "JP"),
            new("Belgium", "BE"),
            new("Kenya", "KE"),
            new("Malta", "MT"),
        };

        context.Countries.AddRange(countries);
        context.SaveChanges();

        var cities = new City[]
        {
            new("Yerevan", 1),
            new("Sydney", 2),
            new("Minsk", 3),
            new("New Delli", 4),
            new("Baghdad", 5),
            new("Tokio", 6),
            new("Bryusel", 7),
            new("Makau", 8),
            new("San Marino", 9),
        };

        context.Cities.AddRangeAsync(cities);
        context.SaveChanges();
    }
}