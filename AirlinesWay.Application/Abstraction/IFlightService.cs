using AirlinesWay.Application.Models;
using AirlinesWay.Domain.Enums;

namespace AirlinesWay.Application.Abstraction;

public interface IFlightService
{
    Task<FlightResponseModel> GetOptimizeFlight(FlightOptimizeWayTypes optimizeType);
    Task<IEnumerable<FlightResponseModel>> GetAllFlights();
}