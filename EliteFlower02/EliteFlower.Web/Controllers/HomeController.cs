using EliteFlower.Core;
using EliteFlower.Services.ManufactureService;
using EliteFlower.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EliteFlower.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IManufactureService _manufacureService;

        public HomeController(ILogger<HomeController> logger,
            IManufactureService manufacureService)
        {
            _logger = logger;
            _manufacureService = manufacureService;
        }

        public IActionResult Index()
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

        [HttpPost]
        public async Task<bool> Insert([FromBody] ManufactureOverview manufactureModel)
        {
            Manufacture manufacture = new Manufacture()
            {
                Name = manufactureModel.Name
            };

            bool response = await _manufacureService.Insert(manufacture);

            return response;
        }

        [HttpPost]
        public async Task<bool> Update([FromBody] ManufactureOverview manufactureModel)
        {
            Manufacture manufacture = new Manufacture()
            {
                Id = manufactureModel.Id,
                Name = manufactureModel.Name
            };

            bool response = await _manufacureService.Update(manufacture);

            return response;
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            bool response = await _manufacureService.Delete(id);

            return response;
        }
    }
}
