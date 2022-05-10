using AirlinesWay.Domain;

namespace AirlinesWay.Application.Abstraction;

public interface IAirCompanyService
{
    Task<IEnumerable<AirCompany>> GetAllAirCompanies();
}