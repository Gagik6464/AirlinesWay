using AirlinesWay.Application.Models;

namespace AirlinesWay.Application.Abstraction;

public interface IAirlineService
{
    Task<IEnumerable<AirlineResponseModel>> GetAllFlights();
}