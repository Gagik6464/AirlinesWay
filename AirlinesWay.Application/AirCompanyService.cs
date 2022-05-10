using AirlinesWay.Application.Abstraction;
using AirlinesWay.Application.Models;
using AirlinesWay.Domain;
using AirlinesWay.Domain.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AirlinesWay.Application;

public class AirCompanyService : IAirCompanyService
{
    private readonly AirlinesWayDbContext _airlinesWayDbContext;
    private readonly IAirlineService _airlineService; 

    public AirCompanyService(AirlinesWayDbContext airlinesWayDbContext, IAirlineService airlineService) {
        _airlinesWayDbContext = airlinesWayDbContext;
        _airlineService = airlineService;
    }

    public async Task<IEnumerable<AirCompany>> GetAllAirCompanies()
    {
        var airCopmanies = await _airlinesWayDbContext.AirCompanies.Include(x => x.Airlines).ToListAsync();

        return airCopmanies;
    }
    
    public async Task<bool> AddAirCompany(AirCompanyResponseModel request) {

        var airlinesByIds = await _airlineService.GetAirLinesByIds(request.AirLineIds); 
        
        var airCompany = new AirCompany(request.Name)
        {
            Airlines = airlinesByIds
        };

        await _airlinesWayDbContext.AirCompanies.AddAsync(airCompany);

        return await _airlinesWayDbContext.SaveChangesAsync() > 0;
    }
}