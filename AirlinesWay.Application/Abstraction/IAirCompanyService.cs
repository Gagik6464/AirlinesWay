using AirlinesWay.Application.Models;
using AirlinesWay.Domain;

namespace AirlinesWay.Application.Abstraction;

public interface IAirCompanyService
{
    Task<IEnumerable<AirCompany>> GetAllAirCompanies();
    Task<bool> AddAirCompany(AirCompanyResponseModel request);
}