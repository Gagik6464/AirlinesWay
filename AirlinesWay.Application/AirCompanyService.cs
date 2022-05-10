using AirlinesWay.Application.Abstraction;
using AirlinesWay.Domain;
using AirlinesWay.Domain.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AirlinesWay.Application;

public class AirCompanyService : IAirCompanyService
{
    private readonly AirlinesWayDbContext _airlinesWayDbContext;

    public AirCompanyService(AirlinesWayDbContext airlinesWayDbContext)
    {
        _airlinesWayDbContext = airlinesWayDbContext;
    }

    public async Task<IEnumerable<AirCompany>> GetAllAirCompanies()
    {
        var airCopmanies = await _airlinesWayDbContext.AirCompanies.Include(x => x.Airlines).ToListAsync();

        return airCopmanies;
    }
}