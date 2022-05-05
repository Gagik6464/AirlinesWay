using AirlinesWay.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AirlinesWay.Controllers;

public class CountriesController : Controller
{
    private readonly ICountryService _countryService;
    // GET
    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _countryService.GetAllCountries();
        return View(response);
    }

    [HttpPost("AddCity")]
    public async Task<IActionResult> AddCity(string cityName, string code)
    {
        var response = await _countryService.AddCountryAsync(cityName, code);
        return View(response);
    }
}