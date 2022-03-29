using Microsoft.AspNetCore.Mvc;
using Project_BerrrasBio.Models;
using System.Diagnostics;

namespace Project_BerrrasBio.Controllers
{
    public class HomepageController : Controller
    {
        private readonly ILogger<HomepageController> _logger;

        public HomepageController(ILogger<HomepageController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
                            
    }
}