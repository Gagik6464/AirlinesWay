using AirlinesWay.Application.Abstraction;
using AirlinesWay.Application.Models;
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

    public async Task<IEnumerable<FlightResponseModel>> GetAllFlights()
    {
        var flights = await _dbContext.Flights
            .Include(x => x.Airline)
            .Include(x => x.AirCompany).ToListAsync();

        var response = flights.Select(flight => new FlightResponseModel
        {
            Name = flight.Name,
            Code = flight.Code,
            StartDateTime = flight.StartDateTime,
            ExpectedFinishDateTime = flight.ExpectedFinishDateTime,
            TimeDuration = flight.TimeDuration,
            Price = flight.Price,
            AirCompanyName = flight.AirCompany.Name,

            AirlineResponse = new()
            {
                Distance = flight.Airline.Distance,
                Id = flight.Airline.Id,
                Name = flight.Airline.Name,
                FinishedCityId = flight.Airline.FinishedCityId,
                IntermediateCityId = flight.Airline.IntermediateCityId,
                StartedCityId = flight.Airline.StartedCityId,
            },
        }).ToList();

        foreach (var item in response)
        {
            item.AirlineResponse.StartedCityName =
                _dbContext.Cities.First(x => x.Id == item.AirlineResponse.StartedCityId).Name;
            
            item.AirlineResponse.IntermediateCityName =
                _dbContext.Cities.FirstOrDefault(x => x.Id == item.AirlineResponse.IntermediateCityId)?.Name;
            
            item.AirlineResponse.FinishedCityName =
                _dbContext.Cities.First(x => x.Id == item.AirlineResponse.FinishedCityId).Name;
        }

        return response;
    }

    public Task<FlightResponseModel> GetOptimizeFlight(FlightOptimizeWayTypes optimizeType)
    {
        return null!;
    }
}