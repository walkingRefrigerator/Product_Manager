using Microsoft.AspNetCore.Mvc;
using Product_Manager.Domain.Repositories.Abstract;
using Product_Manager.Domain.Repositories.EntityFramework;
using System;

namespace Product_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFProductRepositories _context;

        public HomeController (IProductRepositories context)
        {
            _context = (EFProductRepositories)context;
        }


        public IActionResult Index()
        {
            var products = _context.GetAll();

            return View(model: products);
        }

        [HttpPost]
        public IActionResult Index (string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction("Index");
            }

            var products = _context.GetFilterName(name);
            return View(model: products);
        }

        public IActionResult ProductEdit (Guid id)
        {
            Product product = id == default ? new Product() : _context.GetProduct(id);
            return View(model: product);
        }

        [HttpPost]
        public IActionResult ProductEdit (Product product)
        {
            if (ModelState.IsValid)
            {
                _context.PostOrPutProduct(product);
                return RedirectToAction("Index");
            }

            return View(model: product);
        }

        [HttpPost]
        public IActionResult DeleteProduct (Guid id)
        {
            _context.DeleteProduct(id);

            return RedirectToAction("Index");
        }


    }
}
