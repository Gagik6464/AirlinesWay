using AirlinesWay.Domain;
using AirlinesWay.Domain.Enums;

namespace AirlinesWay.Application.Abstraction;

public interface IFlightService
{
    Task<Flight> GetOptimizeFlight(FlightOptimizeWayTypes optimizeType);
    Task<IEnumerable<Flight>> GetAllFlights();
}