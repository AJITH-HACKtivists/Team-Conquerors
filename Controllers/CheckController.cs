using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaHut.Models;
using PizzaHut.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Controllers
{
    public class CheckController : Controller
    {
        public CheckController(IRepo<Toppings> toprepo, IRepo<Pizza> PRepo, ILogger<CheckController> logger)
        {
            _logger = logger;
            _torepo = toprepo;
            _PRepo = PRepo;
        }

        private readonly ILogger<CheckController> _logger;
        private readonly IRepo<Toppings> _torepo;
        private readonly IRepo<Pizza> _PRepo;
        [HttpGet]
        public IActionResult Index(int ID)
        {
            ViewBag.pizza = _PRepo.Get(ID);
            List<Check> check = new List<Check>();
            ICollection<Toppings> topping = _torepo.GetAll();
            foreach (var item in topping)
            {
                Check checks = new Check() { Toppings = item, Checks = false };
                check.Add(checks);
            }
            return View(check);
        }
        [HttpPost]
        public IActionResult Index(int ID, Check toppings)
        {
            if (toppings!=null)
            {
                return RedirectToAction("Details", "Toppings", new { toppings = toppings });
            }
            else
            {
                ViewBag.pizza = _PRepo.Get(ID);
                List<Check> check = new List<Check>();
                ICollection<Toppings> topping = _torepo.GetAll();
                foreach (var item in topping)
                {
                    Check checks = new Check() { Toppings = item, Checks = false };
                    check.Add(checks);
                }
                return View(check);
            }

        }
    }
}
