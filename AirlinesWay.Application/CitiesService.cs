using AirlinesWay.Application.Abstraction;
using AirlinesWay.Domain;
using AirlinesWay.Domain.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AirlinesWay.Application;

public class CitiesService : ICityService
{
    private readonly AirlinesWayDbContext _dbContext;

    public CitiesService(AirlinesWayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<City>> GetAllCities()
    {
        return await _dbContext.Cities.ToListAsync();
    }

    public async Task<bool> AddCityAsync(string cityName, int countryId)
    { 
        await _dbContext.Cities.AddAsync(new City(cityName, countryId));
        return await _dbContext.SaveChangesAsync() > 0;
    }
}