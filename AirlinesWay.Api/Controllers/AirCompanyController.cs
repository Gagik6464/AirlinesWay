using AirlinesWay.Application.Abstraction;
using AirlinesWay.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlinesWay.Controllers;

public class AirCompanyController : Controller {
    private readonly IAirCompanyService _airCompanyService;
    private readonly IAirlineService _airlineService;

    public AirCompanyController(IAirCompanyService airCompanyService, IAirlineService airlineService) {
        _airCompanyService = airCompanyService;
        _airlineService = airlineService;
    }

    public async Task<IActionResult> Index() {
        var airLines = await _airlineService.GetAllAirLines();
        
        var selectList = new List<SelectListItem>();
        var response = new AirCompanyResponseModel();
        
        foreach (var airline in airLines)
        {
            selectList.Add(new()
            {
                Text = airline.Name,
                Value = airline.Id.ToString()
            });
        }
        
        return View(new AirCompanyResponseModel
        {
            Airlines = selectList
        });
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAirCompany(AirCompanyResponseModel request) {
        var response = await _airCompanyService.AddAirCompany(request);
        return Ok(response);
    }
}