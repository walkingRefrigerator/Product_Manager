using Microsoft.AspNetCore.Mvc;
using Product_Manager.Domain.Repositories.Abstract;
using System;

namespace Product_Manager.Controllers
{
    public class HomeController : Controller
    {
        //Добавление контекста базы данных
        private readonly IProductRepositories _context;

        public HomeController (IProductRepositories context)
        {
            _context = context;
        }

        //Основной Action с выводом списка продуктов
        public IActionResult Index()
        {
            //Имя титульника страницы
            ViewData["Title"] = "Список продуктов";

            //Вывод списка продуктов из бд
            var products = _context.GetAll();

            //Передача списка в представление index
            return View(model: products);
        }

        //Action с выводом списка с фильтрацией
        [HttpPost]
        public IActionResult Index (string name)
        {
            //Проверка name на null
            if (string.IsNullOrEmpty(name))
            {
                //Редирект на index
                return RedirectToAction(nameof(Index));
            }

            ViewData["Title"] = "Список продуктов";
            //Вывод отфильтрованного списка продуктов из бд
            var products = _context.GetFilterName(name);
            //Передача отфильрованного списка в представление index
            return View(model: products);
        }

        //Action для вывода модального окна для добавление продукции
        [HttpGet]
        public IActionResult ProductAdd ()
        {
            //Создание нового объекта и его передача в представление модального окна
            Product product = new Product();
            return PartialView("_ProductModalPartial", product);
        }
        
        //Action для добавления/редактирования объекта с модальной формы в бд
        [HttpPost]
        public IActionResult ProductAddOrEdit(Product product)
        {
            //Проверка на коректность входящих данных
            if (ModelState.IsValid)
            {
                //Добавление объекта в бд и переадресация на action index
                _context.PostProduct(product);
                return RedirectToAction(nameof(Index));
            }

            //При неудачной валидации возрат в модальное окно
            return View(model: product);
        }

        //Action для вывода модального окна для редактирования объекта
        [HttpGet]
        public IActionResult ProductEdit(Guid id)
        {
            //Получение объекта из бд и передача в представление модального окна
            Product product = _context.GetProduct(id);
            return PartialView("_ProductModalPartial", product);
        }


        //Action для удаления объекта из бд по id
        [HttpPost]
        public IActionResult DeleteProduct(Guid id)
        {
            _context.DeleteProduct(id);

            //Редирект на action index
            return RedirectToAction(nameof(Index));
        }


    }
}
