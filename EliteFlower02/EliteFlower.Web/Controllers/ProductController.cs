using EliteFlower.Core;
using EliteFlower.Services.ManufactureService;
using EliteFlower.Services.Products;
using EliteFlower.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EliteFlower.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IManufactureService _manufacureService;
        private readonly IProductService _productService;
        private IWebHostEnvironment _environment;

        public ProductController(IManufactureService manufacureService,
            IProductService productService,
            IWebHostEnvironment environment)
        {
            _manufacureService = manufacureService;
            _productService = productService;
            _environment = environment;
        }

        public ActionResult Index()
        {
            IEnumerable<Product> query = _productService.GetAll();


            List<ProductOverview> products = query.Select(x => new ProductOverview()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                PathImage = x.PathImage,
                ManufactureName = _manufacureService.GetById(x.Manufacture).Result.Name
            }).ToList();

            return View(products);
        }

        public ActionResult Details(int id)
        {
            Product product = _productService.GetById(id).Result;

            ProductOverview productModel = new ProductOverview();

            productModel.Id = product.Id;
            productModel.Name = product.Name;
            productModel.Price = product.Price;
            productModel.PathImage = product.PathImage;
            productModel.Manufacture = product.Manufacture;
            productModel.ManufactureName = _manufacureService.GetById(product.Manufacture).Result.Name;

            return View(productModel);
        }

        public ActionResult Create()
        {
            List<Manufacture> query = _manufacureService.GetAll();
            List<ManufactureOverview> manufactures = query.Select(x => new ManufactureOverview()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            ProductOverview productOverview = new ProductOverview();

            productOverview.Manufactures = manufactures;

            return View(productOverview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductOverview productModel, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file.Length > 0)
                    {
                        string wwwPath = Path.Combine(_environment.WebRootPath, _environment.WebRootPath + @"\Products\" + file.FileName);
                        
                        using (var stream = System.IO.File.Create(wwwPath))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }

                    Product product = new Product();

                    product.Name = productModel.Name;
                    product.Price = productModel.Price;
                    product.PathImage = file.FileName;
                    product.Manufacture = productModel.Manufacture;

                    Task<bool> response = _productService.Insert(product);

                    if (response.Result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return RedirectToAction(nameof(Create), productModel);
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Edit(int id)
        {
            Product manufacture = _productService.GetById(id).Result;

            ProductOverview productModel = new ProductOverview();

            productModel.Id = manufacture.Id;
            productModel.Name = manufacture.Name;
            productModel.Price = manufacture.Price;
            productModel.PathImage = manufacture.PathImage;
            productModel.Manufacture = manufacture.Manufacture;

            return View(productModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductOverview productModel, IFormFile file)
        {
            try
            {
                string nameFile = "";

                if (file.Length > 0)
                {
                    string wwwPath = Path.Combine(_environment.WebRootPath, _environment.WebRootPath + @"\Products\" + file.FileName);

                    nameFile = file.FileName;

                    using (var stream = System.IO.File.Create(wwwPath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                Product product = _productService.GetById(id).Result;

                product.Name = productModel.Name;
                product.Price = productModel.Price;
                product.PathImage = nameFile;
                product.Manufacture = productModel.Manufacture;

                Task<bool> response = _productService.Update(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Task<bool> response = _productService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
