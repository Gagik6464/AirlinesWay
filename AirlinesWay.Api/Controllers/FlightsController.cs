using AirlinesWay.Application.Abstraction;
using AirlinesWay.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlinesWay.Controllers;

public class FlightsController : Controller {
    private readonly IFlightService _flightService;
    private readonly IAirCompanyService _airCompanyService;
    private readonly IAirlineService _airlineService;

    public FlightsController(IFlightService flightService, IAirlineService airlineService) {
        _flightService = flightService;
        _airlineService = airlineService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var cities = await _airCompanyService.Get();
        
        var selectCitiesList = new List<SelectListItem>();
        var selectAirLinesList = new List<SelectListItem>();
        var response = new CitiesResponseModel();
        
        foreach (var city in cities)
        {
            selectCitiesList.Add(new()
            {
                Text = city.Name,
                Value = city.Id.ToString()
            });
        }
        
        return View(new AirLineRequestModel()
        {
            Cities = selectCitiesList
        });
        
        return View();
    }

    [HttpPost]
    public IActionResult GetOptimizedFights(CitiesResponseModel request) {
        var result =
            _flightService.GetOptimizeFlight(new FlightGetOptimizeWayModel(request.StartedCityId, request.FinishedCityId,
                request.FilterType));

        return View(result);
    }
    
    [HttpPost("AddFLight")]
    public async Task<IActionResult> AddFlight(FlightRequestModel request) {
        var response = await _flightService.AddFlight(request);
        return Ok(response);
    }
}