using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        public Pizza pizza;
        int Id;
        int Count = 0;
        Dictionary<string, Pizza> Pizza;
        Dictionary<string, Toppings> Topping;
        List<Dictionary<string, Toppings>> ToppingsList;
        List<Dictionary<string, Pizza>> PizzaList;
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
        public IActionResult Index(int ID,string UserID)
        {
            ViewBag.pizza= _PRepo.Get(ID);
            Id = ID;
            TempData["ID"] = ID;
            pizza = _PRepo.Get(ID);
            
            //_logger.LogInformation(TempData["User"].ToString());
            return View(_torepo.GetAll());
        }
        [HttpPost]
        public IActionResult Index(int id, string UserID, Toppings toppings)
        {
            pizza = _PRepo.Get(id);
           
            if (toppings!=null)
            {
                _logger.LogInformation(toppings.ID.ToString());
                int total=(int)(_PRepo.Get((int)TempData["ID"]).Price  + toppings.Price);
                if (TempData["Pizza"] != null)
                {
                    PizzaList = JsonConvert.DeserializeObject<List<Dictionary<string, Pizza>>>(TempData["Pizza"].ToString());
                    Pizza = new Dictionary<string, Pizza>();
                    ToppingsList = JsonConvert.DeserializeObject<List<Dictionary<string, Toppings>>>(TempData["Toppings"].ToString()); ;
                    Topping =new Dictionary<string, Toppings>();
                    Pizza.Add((PizzaList.Count + 1).ToString(), _PRepo.Get((int)TempData["ID"]));
                    PizzaList.Add(Pizza);
                    Count = PizzaList.Count + 1;
                    Topping[Count.ToString()] = toppings;
                    ToppingsList.Add(Topping);
                    TempData["Pizza"] = JsonConvert.SerializeObject(PizzaList);
                    TempData["Toppings"] = JsonConvert.SerializeObject(ToppingsList);
                    _logger.LogInformation(TempData["User"].ToString());
                    TempData["UserID"] = TempData["User"];
                    return RedirectToAction("Details", "Toppings",new {User=UserID });
                }
                else
                {
                    PizzaList = new List<Dictionary<string, Pizza>>();
                    Pizza = new Dictionary<string, Pizza>();
                    ToppingsList = new List<Dictionary<string, Toppings>>();
                    Topping = new Dictionary<string, Toppings>();
                    Pizza.Add((Count+1).ToString(), _PRepo.Get((int)TempData["ID"]));
                    Topping.Add((Count + 1).ToString(), toppings);
                    Count = 1;
                    PizzaList.Add(Pizza);
                    ToppingsList.Add(Topping);
                    TempData["Pizza"] = JsonConvert.SerializeObject(PizzaList);
                    TempData["Toppings"] = JsonConvert.SerializeObject(ToppingsList);
                    _logger.LogInformation(TempData["User"].ToString());
                    TempData["UserID"] = TempData["User"];
                    return RedirectToAction("Details", "Toppings", new { User = UserID });
                }
               
               
            }
            else
            {
                int total= (int) _PRepo.Get((int)TempData["ID"]).Price;
                if (TempData["Pizza"] != null)
                {
                    PizzaList = JsonConvert.DeserializeObject<List<Dictionary<string, Pizza>>>(TempData["Pizza"].ToString());
                    Pizza = new Dictionary<string, Pizza>();
                    Pizza.Add((PizzaList.Count + 1).ToString(), _PRepo.Get((int)TempData["ID"]));
                    PizzaList.Add(Pizza);
                    TempData["Pizza"] = JsonConvert.SerializeObject(PizzaList);
                    TempData["UserID"] = TempData["User"];
                    _logger.LogInformation(TempData["User"].ToString());
                    return RedirectToAction("Details", "Toppings", new { User = UserID });
                }
                else
                {
                    PizzaList = new List<Dictionary<string, Pizza>>();
                    Pizza = new Dictionary<string, Pizza>();
                    Pizza.Add((PizzaList.Count + 1).ToString(), _PRepo.Get((int)TempData["ID"]));
                    PizzaList.Add(Pizza);
                    TempData["Pizza"] = JsonConvert.SerializeObject(PizzaList);
                    TempData["UserID"] = TempData["User"];
                    _logger.LogInformation(TempData["User"].ToString());
                    return RedirectToAction("Details", "Toppings", new { User = UserID });
                   
                }

            }
          
        }
        public IActionResult Details(string User)
        {
            _logger.LogInformation(User);
            ViewBag.User = User;
            //_logger.LogInformation(TempData["UserID"].ToString());
            TempData["UserID"] = TempData["User"];
            return View();
        }

    }
}
