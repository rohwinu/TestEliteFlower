using EliteFlower.Core;
using EliteFlower.Services.ManufactureService;
using EliteFlower.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteFlower.Web.Controllers
{
    public class ManufactureController : Controller
    {

        private readonly IManufactureService _manufacureService;

        public ManufactureController(IManufactureService manufacureService)
        {
            _manufacureService = manufacureService;
        }

        //Method for view all Manufactures
        public ActionResult Index()
        {
            IEnumerable<Manufacture> query = _manufacureService.GetAll();

            List<ManufactureOverview> manufactures = query.Select(x => new ManufactureOverview()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return View(manufactures);
        }

        //Method for call the Create View
        public ActionResult Create()
        {
            return View(new ManufactureOverview());
        }

        //Method for create a Manufacture
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(ManufactureOverview manufactureModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Manufacture manufacture = new Manufacture();
                    manufacture.Name = manufactureModel.Name;
                    Task<bool> response = _manufacureService.Insert(manufacture);

                    if (response.Result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return RedirectToAction(nameof(Create), manufactureModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            Manufacture manufacture = _manufacureService.GetById(id).Result;

            ManufactureOverview manufactureModel = new ManufactureOverview();

            manufactureModel.Id = manufacture.Id;
            manufactureModel.Name = manufacture.Name;

            return View(manufactureModel);
        }

        public ActionResult Edit(int id)
        {
            Manufacture manufacture = _manufacureService.GetById(id).Result;

            ManufactureOverview manufactureModel = new ManufactureOverview();

            manufactureModel.Id = manufacture.Id;
            manufactureModel.Name = manufacture.Name;

            return View(manufactureModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ManufactureOverview manufactureModel)
        {
            try
            {
                Manufacture manufacture = _manufacureService.GetById(id).Result;

                manufacture.Name = manufactureModel.Name;

                Task<bool> response = _manufacureService.Update(manufacture);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Task<bool> response = _manufacureService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
