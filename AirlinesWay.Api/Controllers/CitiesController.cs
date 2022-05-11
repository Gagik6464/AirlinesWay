using AirlinesWay.Application.Abstraction;
using AirlinesWay.Application.Models;
using AirlinesWay.Domain;
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
    public async Task<IActionResult> Index(dynamic cityId)
    {
        var citiesResponse = await _cityService.GetAllCities();

        var selectList = new List<SelectListItem>();
        var response = new CitiesResponseModel();
        
        foreach (var city in citiesResponse)
        {
            selectList.Add(new()
            {
                Text = city.Name,
                Value = city.Id.ToString()
            });
        }

        response.Cities = selectList;
        
        return View(response);
    }

    [HttpPost("AddCity")]
    public async Task<IActionResult> AddCity(string cityName, int countryId)
    {
        var response = await _cityService.AddCityAsync(cityName, countryId);
        
        return View(response);
    }
}