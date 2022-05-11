using AirlinesWay.Application.Abstraction;
using AirlinesWay.Application.Models;
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

    public FlightResponseModel GetOptimizeFlight(FlightGetOptimizeWayModel request) {
        
        var flights = _dbContext.Flights
            .Include(x => x.Airline)
            .Include(x => x.AirCompany).Where(x => x.Airline.StartedCityId == request.StartCityId &&
                                                   x.Airline.FinishedCityId == request.FinishedCityId).ToList();
        
        var flight = request.FilterType switch
        {
            (int) FlightOptimizeWayTypes.ByValue =>
        
                flights.MinBy(x => x.Price)
        ,
            (int) FlightOptimizeWayTypes.ByRoadLength =>  flights.MinBy(x => x.Airline.Distance),
            
            (int) FlightOptimizeWayTypes.ByTimeDuration => flights.MinBy(x => x.TimeDuration),
            _ => throw new ArgumentOutOfRangeException()
        };

        if (flight is null)
            return new FlightResponseModel();

        var response =  new FlightResponseModel
        {
            Id = flight.Id,
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
        };
        
        response.AirlineResponse.StartedCityName =
            _dbContext.Cities.First(x => x.Id == response.AirlineResponse.StartedCityId).Name;
        
        response.AirlineResponse.IntermediateCityName =
            _dbContext.Cities.FirstOrDefault(x => x.Id == response.AirlineResponse.IntermediateCityId)?.Name;
        
        response.AirlineResponse.FinishedCityName =
            _dbContext.Cities.First(x => x.Id == response.AirlineResponse.FinishedCityId).Name;

        return response;
    }
    
    public async Task<bool> AddFlight(FlightRequestModel request) {

        return await _dbContext.Database.ExecuteSqlRawAsync("sp_InsertFlightInfo @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7", 
            request.Name, 
            request.Code,
            request.StartDateTime,
            request.ExpectedFinishDateTime,
            request.TimeDuration,
            request.Price,
            request.AirCompanyId,
            request.AirlineId
        ) > 0;
    }
}