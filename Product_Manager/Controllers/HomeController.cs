using Microsoft.AspNetCore.Mvc;
using Product_Manager.Domain.Repositories.Abstract;
using Product_Manager.Domain.Repositories.EntityFramework;
using System;

namespace Product_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepositories _context;

        public HomeController (IProductRepositories context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            ViewData["Title"] = "Список продуктов";

            var products = _context.GetAll();

            return View(model: products);
        }

        [HttpPost]
        public IActionResult Index (string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction(nameof(Index));
            }

            var products = _context.GetFilterName(name);
            return View(model: products);
        }


        [HttpGet]
        public IActionResult ProductAdd ()
        {
            Product product = new Product();
            return PartialView("_ProductModelPartial", product);
        }
        
        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.PostProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View(model: product);
        }

        [HttpGet]
        public IActionResult ProductEdit(Guid id)
        {
            Product product = _context.GetProduct(id);
            return PartialView("_ProductModelPartial", product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(Guid id)
        {
            _context.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }


    }
}
