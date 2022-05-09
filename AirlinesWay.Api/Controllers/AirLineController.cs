using AirlinesWay.Application.Abstraction;
using AirlinesWay.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlinesWay.Controllers;

public class AirLineController : Controller {
    private readonly IAirlineService _airlineService;

    private readonly ICityService _cityService;
    // GET
    public AirLineController(IAirlineService airlineService, ICityService cityService) {
        _airlineService = airlineService;
        _cityService = cityService;
    }

    [HttpGet("Index")]
    public async Task<IActionResult> Index() {
        var cities = await _cityService.GetAllCities();
        
        var selectList = new List<SelectListItem>();
        var response = new CitiesResponseModel();
        
        foreach (var city in cities)
        {
            selectList.Add(new()
            {
                Text = city.Name,
                Value = city.Id.ToString()
            });
        }
        
        return View(new AirLineRequestModel()
        {
            Cities = selectList
        });
    }
    
    [HttpPost("AddAirline")]
    public async Task<IActionResult> AddAirline(AirLineRequestModel request) {
        var response = await _airlineService.AddAirLine(request);
        return Ok(response);
    }
}