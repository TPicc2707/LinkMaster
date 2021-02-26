using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinkMasters.Models;
using LinkMasters.Data.Interface;

namespace LinkMasters.Controllers
{
    public class HomeController : Controller
    {
        private ILinksRepository _repository;

        public HomeController(ILinksRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            int applicationId = 4;

            var getHomeLinks = _repository.GetLinksByApplicationId(applicationId);
            return View(await getHomeLinks);
        }

        public IActionResult Leave()
        {
            return View();
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
