using AirlinesWay.Application.Abstraction;
using AirlinesWay.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlinesWay.Controllers;

public class FlightsController : Controller {
    private readonly IFlightService _flightService;
    private readonly IAirCompanyService _airCompanyService;
    private readonly IAirlineService _airlineService;

    public FlightsController(IFlightService flightService, IAirlineService airlineService, IAirCompanyService airCompanyService) {
        _flightService = flightService;
        _airlineService = airlineService;
        _airCompanyService = airCompanyService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var aircompanies = await _airCompanyService.GetAllAirCompanies();
        var airLines = await _airlineService.GetAllAirLines();

        var selectAirCompaniesList = aircompanies.Select(airCompany => new SelectListItem() {Text = airCompany.Name, Value = airCompany.Id.ToString()}).ToList();

        return View(new FlightRequestModel()
        {
            AirCompanies = selectAirCompaniesList
        });
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