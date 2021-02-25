using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using ChefsNDishes.Context;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> chefs= _context.Chefs
                .Include(c => c.ChefDishes)
                .ToList();
            return View(chefs);
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> dishes = _context.Dishes
                .Include(d => d.ChefOfDish)
                .ToList();
            return View(dishes);
        }

        [HttpGet("add/chef")]
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpGet("add/dish")]
        public IActionResult AddDish()
        {
            ViewBag.ChefsOfDish = _context.Chefs
                .ToList();
            return View();
        }

        [HttpPost("create/chef")]
        public IActionResult CreateChef(Chef chef)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef", chef);
            }
        }

        [HttpPost("create/dish")]
        public IActionResult CreateDish(Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dish);
                _context.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                return View("AddDish", dish);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
