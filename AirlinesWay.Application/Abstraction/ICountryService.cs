using AirlinesWay.Domain;

namespace AirlinesWay.Application.Abstraction;

public interface ICountryService
{
    Task<IEnumerable<Country>> GetAllCountries();
    Task<bool> AddCountryAsync(string countryName, string code);
}