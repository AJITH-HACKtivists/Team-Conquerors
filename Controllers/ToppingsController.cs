using Microsoft.AspNetCore.Http;
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
        static int Count = 0;
        static double total = 0;
        public Dictionary<string, Toppings> ToppingsList;
        public Dictionary<string, Cart> PizzaList;
        private readonly IRepo<Users> _repo;
        private readonly ILogger<ToppingsController> _logger;
        private readonly IRepo<Toppings> _toprepo;
        private readonly IRepo<Pizza> _PRepo;
        Cart cart;
        public ToppingsController(ILogger<ToppingsController> logger, IRepo<Users> repo, IRepo<Toppings> toprepo, IRepo<Pizza> PRepo)
        {
            _repo = repo;
            _logger = logger;
            _toprepo = toprepo;
            _PRepo = PRepo;
            PizzaList = new Dictionary<string, Cart>();
            ToppingsList = new Dictionary<string, Toppings>();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetToppings(int ID)
        {
            TempData["ID"] = ID;
            TempData.Keep("ID");
            pizza = _PRepo.Get(ID);
            ViewBag.pizza = _PRepo.Get(ID);
            HttpContext.Session.SetString("ID", ID.ToString());
            Check checks = new Check();
            checks.Toppings = _toprepo.GetAll();
            return View(checks);
        }
        [HttpPost]
        public IActionResult GetToppings(int ID, Check check)
        {
            _logger.LogInformation("Pizza ID is " + ID.ToString());
            int IDD = Convert.ToInt32(HttpContext.Session.GetString("ID"));
            int TopID = check.checks;
            _logger.LogInformation("ToppingID" + check.checks.ToString());
            _logger.LogInformation("Pizza Id is" + IDD);
            if (check.checks != 0)
            {
                _logger.LogInformation("ToppingID  " + check.checks.ToString());
                _logger.LogInformation("Topping name " + _toprepo.Get(TopID).Name);
                //total += _PRepo.Get(ID).Price + _toprepo.Get(check.checks).Price;
                if (HttpContext.Session.GetString("Pizza") != null && HttpContext.Session.GetString("Toppings") != null)
                {
                    PizzaList = JsonConvert.DeserializeObject<Dictionary<string, Cart>>(HttpContext.Session.GetString("Pizza"));
                    ToppingsList = JsonConvert.DeserializeObject<Dictionary<string, Toppings>>(HttpContext.Session.GetString("Toppings"));
                    foreach (var item in PizzaList.Keys)
                    {
                        if (PizzaList[item].Pizza.ID == ID && ToppingsList.ContainsKey(item) && ToppingsList[item].ID == TopID)
                        {
                            PizzaList[item].Qty+=1;
                            HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                            HttpContext.Session.SetString("Toppings", JsonConvert.SerializeObject(ToppingsList));
                            TempData["Added"] = "Successfully Added";
                            _logger.LogInformation("Pizza Already Exists");
                            return RedirectToAction("Details", "Toppings");
                        }
                    }
                    Count = PizzaList.Count + 1;
                    cart=new Cart() {Pizza=_PRepo.Get((int)TempData.Peek("ID")),Qty=1 };
                    PizzaList.Add((PizzaList.Count + 1).ToString(),cart);
                    ToppingsList.Add(Count.ToString(), _toprepo.Get(TopID));
                    //TempData["Pizza"] = JsonConvert.SerializeObject(PizzaList);
                    //TempData["Toppings"] = JsonConvert.SerializeObject(ToppingsList);
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    HttpContext.Session.SetString("Toppings", JsonConvert.SerializeObject(ToppingsList));
                    TempData["Added"] = "Successfully Added";
                    return RedirectToAction("Details", "Toppings");
                }
                else if (HttpContext.Session.GetString("Pizza") != null && HttpContext.Session.GetString("Toppings") == null)
                {
                    PizzaList = JsonConvert.DeserializeObject<Dictionary<string, Cart>>(HttpContext.Session.GetString("Pizza"));
                    ToppingsList = new Dictionary<string, Toppings>();
                    cart = new Cart() { Pizza = _PRepo.Get((int)TempData.Peek("ID")), Qty = 1 };
                    PizzaList.Add((PizzaList.Count + 1).ToString(), cart);
                    ToppingsList.Add((PizzaList.Count + 1).ToString(), _toprepo.Get(TopID));
                    Count = 1;
                    //TempData["Pizza"] = JsonConvert.SerializeObject(PizzaList);
                    //TempData["Toppings"] = JsonConvert.SerializeObject(ToppingsList);
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    HttpContext.Session.SetString("Toppings", JsonConvert.SerializeObject(ToppingsList));
                    TempData["Added"] = "Successfully Added";
                    return RedirectToAction("Details", "Toppings");
                }
                else
                {
                    PizzaList = new Dictionary<string, Cart>();
                    ToppingsList = new Dictionary<string, Toppings>();
                    cart = new Cart() { Pizza = _PRepo.Get((int)TempData.Peek("ID")), Qty = 1 };
                    PizzaList.Add((PizzaList.Count + 1).ToString(),cart);
                    ToppingsList.Add((PizzaList.Count).ToString(), _toprepo.Get(TopID));
                    Count = 1;
                    //TempData["Pizza"] = JsonConvert.SerializeObject(PizzaList);
                    //TempData["Toppings"] = JsonConvert.SerializeObject(ToppingsList);
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    HttpContext.Session.SetString("Toppings", JsonConvert.SerializeObject(ToppingsList));
                    TempData["Added"] = "Successfully Added";
                    return RedirectToAction("Details", "Toppings");
                }
            }
            else
            {
                total += _PRepo.Get((int)TempData.Peek("ID")).Price;

                if (HttpContext.Session.GetString("Pizza") != null)
                {
                    PizzaList = JsonConvert.DeserializeObject<Dictionary<string, Cart>>(HttpContext.Session.GetString("Pizza"));
                    ToppingsList = JsonConvert.DeserializeObject<Dictionary<string, Toppings>>(HttpContext.Session.GetString("Toppings"));
                    foreach (var item in PizzaList.Keys)
                    {
                        if (PizzaList[item].Pizza.ID == ID && !ToppingsList.ContainsKey(item))
                        {
                            PizzaList[item].Qty += 1;
                            HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                            TempData["Added"] = "Successfully Added";
                            _logger.LogInformation("Pizza Already Exists");
                            return RedirectToAction("Details", "Toppings");
                        }
                    }
                    cart = new Cart() { Pizza = _PRepo.Get((int)TempData.Peek("ID")), Qty = 1 };
                    PizzaList.Add((PizzaList.Count + 1).ToString(), cart);
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    //ViewBag.Pizza = HttpContext.Session.GetString("Pizza");
                    TempData["Pizza"] = HttpContext.Session.GetString("Pizza");
                    TempData.Keep("Pizza");
                    TempData["Added"] = "Successfully Added";
                    return RedirectToAction("Details", "Toppings");
                }
                else
                {
                    PizzaList = new Dictionary<string, Cart>();
                    cart = new Cart() { Pizza = _PRepo.Get((int)TempData.Peek("ID")), Qty = 1 };
                    PizzaList.Add((PizzaList.Count + 1).ToString(),cart);
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    TempData["Added"] = "Successfully Added";
                    return RedirectToAction("Details", "Toppings");

                }

            }

        }
        public IActionResult Details()
        {
            ViewBag.UserID = HttpContext.Session.GetString("UserID");
            _logger.LogInformation(total.ToString());
            PizzaList = JsonConvert.DeserializeObject<Dictionary<string, Cart>>(HttpContext.Session.GetString("Pizza"));
            if (HttpContext.Session.GetString("Toppings") != null)
            {
                ToppingsList = JsonConvert.DeserializeObject<Dictionary<string, Toppings>>(HttpContext.Session.GetString("Toppings"));
                ViewData["Toppings"] = ToppingsList;
                _logger.LogInformation("List Toppings Size " + ToppingsList.Count.ToString());
            }
            else
            {
                ViewData["Toppings"] = null;
            }
            ViewData["Pizza"] = PizzaList;
            _logger.LogInformation("List pizza size " + PizzaList.Count.ToString());

            return View();
        }
        public IActionResult Delete(string ID)
        {
            PizzaList = JsonConvert.DeserializeObject<Dictionary<string, Cart>>(HttpContext.Session.GetString("Pizza"));
            ToppingsList = JsonConvert.DeserializeObject<Dictionary<string, Toppings>>(HttpContext.Session.GetString("Pizza"));
            if (PizzaList.ContainsKey(ID) && ToppingsList.ContainsKey(ID))
            {
                if (PizzaList[ID].Qty == 1)
                {
                    PizzaList.Remove(ID);
                    ToppingsList.Remove(ID);
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    HttpContext.Session.SetString("Toppings", JsonConvert.SerializeObject(ToppingsList));
                    return RedirectToAction("Details", "Toppings");
                }
                else
                {
                    PizzaList[ID].Qty -= 1;
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    return RedirectToAction("Details", "Toppings");
                }

            }
            else
            {
                if (PizzaList[ID].Qty == 1)
                {
                    PizzaList.Remove(ID);
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    HttpContext.Session.SetString("Toppings", JsonConvert.SerializeObject(ToppingsList));
                    return RedirectToAction("Details", "Toppings");
                }
                else
                {
                    PizzaList[ID].Qty -= 1;
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    HttpContext.Session.SetString("Toppings", JsonConvert.SerializeObject(ToppingsList));
                    return RedirectToAction("Details", "Toppings");
                }
            }
        }
        public IActionResult Add(string ID)
        {
            PizzaList= PizzaList = JsonConvert.DeserializeObject<Dictionary<string, Cart>>(HttpContext.Session.GetString("Pizza"));
            PizzaList[ID].Qty += 1;
            HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
            return RedirectToAction("Details", "Toppings");
        }
    }
}
