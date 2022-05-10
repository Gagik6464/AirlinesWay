using AirlinesWay.Application.Models;

namespace AirlinesWay.Application.Abstraction;

public interface IAirlineService
{
    Task<IEnumerable<AirlineResponseModel>> GetAllAirLines();
    Task<bool> AddAirLine(AirLineRequestModel request);
}