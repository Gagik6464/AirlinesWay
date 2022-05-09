using AirlinesWay.Application.Abstraction;

namespace AirlinesWay.Application;

public class AirCompanyService : IAirCompanyService
{
	// public async Task<IEnumerable<AirlineResponseModel>> GetAllFlights()
	// {
	// 	var airlines =  await _dbContext.Airlines.ToListAsync();
 //        
	// 	var response = airlines.Select(airline => new AirlineResponseModel
	// 	{
	// 		Id = airline.Id,
	// 		Name = airline.Name,
	// 		Distance = airline.Distance,
	// 		CurrentlyFlightCount = airline.Flights.Count
	// 	}).ToList();
 //        
	// 	foreach (var item in response)
	// 	{
	// 		item.StartedCityName =
	// 			_dbContext.Cities.First(x => x.Id == item.StartedCityId).Name;
 //            
	// 		item.IntermediateCityName =
	// 			_dbContext.Cities.FirstOrDefault(x => x.Id == item.IntermediateCityId)?.Name;
 //            
	// 		item.FinishedCityName =
	// 			_dbContext.Cities.First(x => x.Id == item.FinishedCityId).Name;
	// 	}
	//
	// 	return response;
	// }
}
