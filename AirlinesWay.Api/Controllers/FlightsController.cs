using Microsoft.AspNetCore.Mvc;

namespace AirlinesWay.Controllers;

public class FlightsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}