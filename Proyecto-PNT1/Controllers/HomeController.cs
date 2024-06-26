using Microsoft.AspNetCore.Mvc;
using Proyecto_PNT1.Models;
using System.Diagnostics;

namespace Proyecto_PNT1.Controllers
{
    public class HomeController : Controller
    {
    public IActionResult Index()
        {
            return View();
        }

    public IActionResult Privacy()
        {
            return View();
        }
    }
}

