using AirlinesWay.Application.Models;

namespace AirlinesWay.Application.Abstraction;

public interface IFlightService
{
    FlightResponseModel GetOptimizeFlight(FlightGetOptimizeWayModel request);
    Task<IEnumerable<FlightResponseModel>> GetAllFlights();
}