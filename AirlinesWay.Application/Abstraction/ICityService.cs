using AirlinesWay.Domain;

namespace AirlinesWay.Application.Abstraction;

public interface ICityService
{
    Task<IEnumerable<City>> GetAllCities();
    Task<bool> AddCityAsync(string cityName, int countryId);
}