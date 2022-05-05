using AirlinesWay.Application.Abstraction;
using AirlinesWay.Domain;
using AirlinesWay.Domain.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AirlinesWay.Application;

public class CountryService : ICountryService
{
    private readonly AirlinesWayDbContext _dbContext;

    public CountryService(AirlinesWayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        return await _dbContext.Countries.ToListAsync();
    }

    public async Task<bool> AddCountryAsync(string countryName, string code)
    { 
        await _dbContext.Countries.AddAsync(new Country(countryName, code));
        return await _dbContext.SaveChangesAsync() > 0;
    }
}