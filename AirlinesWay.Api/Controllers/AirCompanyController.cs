using Microsoft.AspNetCore.Mvc;

namespace AirlinesWay.Controllers;

public class AirCompanyController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}