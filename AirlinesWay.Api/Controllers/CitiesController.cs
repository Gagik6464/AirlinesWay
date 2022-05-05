using AirlinesWay.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlinesWay.Controllers;

public class CitiesController : Controller
{
    private readonly ICityService _cityService;
    // GET
    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var citiesResponse = await _cityService.GetAllCities();

        var response = new List<SelectListItem>();
        
        foreach (var city in citiesResponse)
        {
            response.Add(new()
            {
                Text = city.Name,
                Value = city.Name
            });
        }
        
        return View(response);
    }

    [HttpPost("AddCity")]
    public async Task<IActionResult> AddCity(string cityName, int countryId)
    {
        var response = await _cityService.AddCityAsync(cityName, countryId);
        
        return View(response);
    }
}