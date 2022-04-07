using AirlinesWay.Application.Abstraction;
using AirlinesWay.Domain;
using AirlinesWay.Domain.DbContext;
using AirlinesWay.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AirlinesWay.Application;

public class FlightService : IFlightService
{
    private readonly AirlinesWayDbContext _dbContext;

    public FlightService(AirlinesWayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Flight>> GetAllFlights()
    {
        return await _dbContext.Flights.ToListAsync();
    }

    public Task<Flight> GetOptimizeFlight(FlightOptimizeWayTypes optimizeType)
    {
        return null!;
    }
}