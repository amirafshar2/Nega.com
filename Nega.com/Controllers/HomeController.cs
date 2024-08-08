using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nega.com.Models;
using Negacom.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nega.com.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VisitorCounterService _visitorCounterService;

        public HomeController(ILogger<HomeController> logger, VisitorCounterService visitorCounterService)
        {
            _logger = logger;
            _visitorCounterService = visitorCounterService;
        }

        public IActionResult Index()
        {
            _visitorCounterService.IncrementCounter();
            return RedirectToAction("Index","Nega");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}
