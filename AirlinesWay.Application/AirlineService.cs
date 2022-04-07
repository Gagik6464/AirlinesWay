using AirlinesWay.Application.Abstraction;
using AirlinesWay.Domain;
using AirlinesWay.Domain.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AirlinesWay.Application;

public class AirlineService : IAirlineService
{
    private readonly AirlinesWayDbContext _dbContext;

    public AirlineService(AirlinesWayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Airline>> GetAllFlights()
    {
        return await _dbContext.Airlines.ToListAsync();
    }
}