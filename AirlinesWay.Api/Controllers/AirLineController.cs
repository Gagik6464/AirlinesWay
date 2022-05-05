using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AirlinesWay.Controllers;

public class AirLineController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}