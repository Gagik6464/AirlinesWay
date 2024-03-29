using AirlinesWay.Application.Abstraction;
using AirlinesWay.Application.Models;
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

    public async Task<IEnumerable<AirlineResponseModel>> GetAllAirLines()
    {
        var airlines =  await _dbContext.Airlines.Include(x =>x.AirCompanies)
            .Include(x => x.Flights).ToListAsync();

        if (!airlines.Any()) return new List<AirlineResponseModel>();
        {
            var response = airlines.Select(airline => new AirlineResponseModel
            {
                Id = airline.Id,
                Name = airline.Name,
                Distance = airline.Distance,
                CurrentlyFlightCount = airline.Flights == null || !airline.Flights.Any() ? 0 : airline.Flights.Count,
                AirCompanyIds = airline.AirCompanies == null || !airline.AirCompanies.Any() ? null : airline.AirCompanies?.Select(x => x.Id),
                StartedCityId = airline.StartedCityId,
                IntermediateCityId = airline.IntermediateCityId,
                FinishedCityId = airline.FinishedCityId
            }).ToList();
        
            foreach (var item in response)
            {
                item.StartedCityName =
                    _dbContext.Cities.First(x => x.Id == item.StartedCityId).Name;
            
                item.IntermediateCityName =
                    _dbContext.Cities.FirstOrDefault(x => x.Id == item.IntermediateCityId)?.Name;
            
                item.FinishedCityName =
                    _dbContext.Cities.First(x => x.Id == item.FinishedCityId).Name;
            }

            return response;
        }
    }
    public async Task<IEnumerable<Airline>> GetAirLinesByIds(IEnumerable<int> ids)
    {
        var airlines =  await _dbContext.Airlines.Include(x =>x.AirCompanies)
            .Include(x => x.Flights).Where(x => ids.Contains(x.Id)).ToListAsync();

            return airlines;
    }

    public async Task<bool> AddAirLine(AirLineRequestModel request) {

        var requestedAirline = new Airline(request.Name, request.StartedCityId, request.FinishedCityId) {
            Distance = request.Distance,
            IntermediateCityId = request.IntermediateCityId,
        };

        await _dbContext.Airlines.AddAsync(requestedAirline);

        return await _dbContext.SaveChangesAsync() > 0;
    }
}