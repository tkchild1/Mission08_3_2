using Microsoft.AspNetCore.Mvc;
using Mission08_3_2.Models;
using System.Diagnostics;

namespace Mission08_3_2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
