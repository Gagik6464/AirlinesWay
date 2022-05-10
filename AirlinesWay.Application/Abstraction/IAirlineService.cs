using AirlinesWay.Application.Models;
using AirlinesWay.Domain;

namespace AirlinesWay.Application.Abstraction;

public interface IAirlineService
{
    Task<IEnumerable<AirlineResponseModel>> GetAllAirLines();
    Task<bool> AddAirLine(AirLineRequestModel request);
    Task<IEnumerable<Airline>> GetAirLinesByIds(IEnumerable<int> ids);
}