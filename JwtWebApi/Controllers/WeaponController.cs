using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers;

public class WeaponController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}