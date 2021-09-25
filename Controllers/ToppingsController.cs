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
    public class ToppingsController : Controller
    {
        private Pizza pizza;
        int Count = 0;
        List<int> Topping = new List<int>(); 
        public ToppingsController(IRepo<Toppings> toprepo,IRepo<Pizza> PRepo,ILogger<ToppingsController> logger)
        {
            _logger = logger;
            _torepo = toprepo;
            _PRepo = PRepo;
        }

        private readonly ILogger<ToppingsController> _logger;
        private readonly IRepo<Toppings> _torepo;
        private readonly IRepo<Pizza> _PRepo;
        [HttpGet]
        public IActionResult Index(int ID)
        {
            ViewBag.pizza= _PRepo.Get(ID);
            return View(_torepo.GetAll());
        }
        [HttpPost]
        public IActionResult Index(int ID,int toppings)
        {
            
            if (toppings!= 0)
            {
                _logger.LogError("Success");
                ViewBag.pizza = _PRepo.Get(ID);
                return View(_torepo.GetAll());

            }
            else
            {
                _logger.LogError("failure");
                ViewBag.pizza = _PRepo.Get(ID);
                return View(_torepo.GetAll());
            }
        }
        //public IActionResult Details()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Details(List<int> toppings)
        //{
        //    await Topping.Add(10);
        //    if (toppings.Count>0)
        //    {
        //        _logger.LogError("Success");
        //        return View();

        //    }
        //    else
        //    {
        //        _logger.LogError("failure");
        //        return View();
        //    }
        //}
    }
}
