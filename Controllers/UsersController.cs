using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using PizzaHut.Models;
using PizzaHut.Services;
using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PizzaHut.Controllers
{
    public class UsersController : Controller
    {
        public Pizza pizza;
        private readonly IRepo<Users> _repo;
        private readonly ILogger<UsersController> _logger;
        private readonly IRepo<Toppings> _toprepo;
        private readonly IRepo<Pizza> _PRepo;
        private Regex regex;
        int Count = 0;
        static int Id;
        static double total = 0;
        static string UserId;
        Dictionary<string, Toppings> ToppingsList;
        Dictionary<string, Pizza> PizzaList;
        public UsersController(ILogger<UsersController> logger, IRepo<Users> repo, IRepo<Toppings> toprepo, IRepo<Pizza> PRepo)
        {
            _repo = repo;
            _logger = logger;
            _toprepo = toprepo;
            _PRepo = PRepo;
          
        }
  
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Users user)
        {
            if (string.IsNullOrEmpty(user.UserID) || string.IsNullOrWhiteSpace(user.UserID))
            {
                ViewBag.ErrorUser = "Enter Valid Email";
                return View();
            }
            else if (string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Password))
            {
                ViewBag.ErrorPassword = "Invalid Password";
                return View();
            }
            else
            {
                Users users = _repo.Validate(user);
                if (users != null)
                {
                    ViewBag.Success1 = "Login Successfull";
                    //TempData["UserName"] = users.Name;
                    TempData["UserID"] = users.UserID;
                    TempData.Keep("UserID");
                    HttpContext.Session.SetString("UserID", user.UserID);
                    //TempData["CustID"] = users.ID;
                    ViewBag.UserID = users.UserID;
                    return RedirectToAction("Pizzas", "Users", new { UsersID = user.UserID });
                }
                else
                {
                    ViewBag.Error = "No Such User Present";
                    return View();
                }
            }

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Users user)
        {
            if (string.IsNullOrEmpty(user.UserID) || string.IsNullOrWhiteSpace(user.UserID) || !ValidateEmailAddress(user.UserID))
            {
                ViewBag.ErrorUser = "Enter Valid Email";
                return View();
            }
            else if (string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Password) || !ValidatePassword(user.Password))
            {
                ViewBag.ErrorPassword = "Invalid Password";
                return View();
            }
            else if (string.IsNullOrEmpty(user.Name) || string.IsNullOrWhiteSpace(user.Name))
            {
                ViewBag.ErrorName = "Ïnvalid Name";
                return View();
            }
            else if (string.IsNullOrEmpty(user.Phone) || string.IsNullOrWhiteSpace(user.Phone) || ValidatePhone(user.Phone))
            {
                ViewBag.ErrorPhone = "Invalid Phone Number";
            }
            else if (string.IsNullOrEmpty(user.Address) || string.IsNullOrWhiteSpace(user.Address))
            {
                ViewBag.ErrorAddress = "Invalid Address";
                return View();
            }
            else
            {
                Users users = _repo.Validate2(user);
                if (users!= null)
                {
                    ViewBag.Error = "User Already Exists";
                    return View();
                }
                else if (_repo.Add(user) != null)
                {
                   
                    TempData["UserID"] = users.UserID;
                    TempData.Keep("UserID");
                    HttpContext.Session.SetString("UserID", user.UserID);
                    ViewBag.Success = "Registeration Successfull";
                    
                    return RedirectToAction("Pizzas", "Users",new { UsersID=user.UserID});
                }
                else
                {
                    ViewBag.Error = "Some Error Occured";
                    return View();
                }

            }
            return View();
        }
        public IActionResult Pizzas()
        {
           
            return View(_PRepo.GetAll());
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
            checks.Toppings= _toprepo.GetAll();
            return View(checks);
        }
        [HttpPost]
        public IActionResult Get(Check check)
        {
            int ID = Convert.ToInt32(HttpContext.Session.GetString("ID"));
            int TopID = check.checks;
            _logger.LogInformation("ToppingID"+check.checks.ToString());
            _logger.LogInformation("Pizza Id is" + ID);
            if (check.checks != 0)
            {
                _logger.LogInformation("ToppingID" + check.checks.ToString());
                _logger.LogInformation("Topping name" + _toprepo.Get(TopID).Name);
                //total += _PRepo.Get(ID).Price + _toprepo.Get(check.checks).Price;
                if (HttpContext.Session.GetString("Pizza") != null)
                {
                    PizzaList = JsonConvert.DeserializeObject<Dictionary<string, Pizza>>(HttpContext.Session.GetString("Pizza"));
                    ToppingsList = JsonConvert.DeserializeObject<Dictionary<string, Toppings>>(HttpContext.Session.GetString("Toppings"));
                    foreach(var item in PizzaList.Keys)
                    {
                        if(PizzaList[item].ID==ID && ToppingsList.ContainsKey(item) && ToppingsList[item].ID == TopID)
                        {
                            _logger.LogInformation("Pizza Already Exists");
                            return RedirectToAction("Pizzas", "Users");
                        }
                    }
                    Count = PizzaList.Count + 1;
                    PizzaList.Add((PizzaList.Count + 1).ToString(), _PRepo.Get((int)TempData["ID"]));
                    ToppingsList.Add(Count.ToString(),_toprepo.Get(TopID));
                    //TempData["Pizza"] = JsonConvert.SerializeObject(PizzaList);
                    //TempData["Toppings"] = JsonConvert.SerializeObject(ToppingsList);
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    HttpContext.Session.SetString("Toppings", JsonConvert.SerializeObject(ToppingsList));
                    TempData["Pizza"] = HttpContext.Session.GetString("Pizza");
                    TempData["Toppings"] = HttpContext.Session.GetString("Toppings");
                    TempData.Keep("Toppings");
                    TempData.Keep("Pizza");
                    return RedirectToAction("Details", "Users");
                }
                else
                {
                    PizzaList = new Dictionary<string, Pizza>();
                    ToppingsList = new Dictionary<string, Toppings>();
                    PizzaList.Add((Count + 1).ToString(), _PRepo.Get((int)TempData.Peek("ID")));
                    ToppingsList.Add((Count + 1).ToString(), _toprepo.Get(TopID));
                    Count = 1;
                    //TempData["Pizza"] = JsonConvert.SerializeObject(PizzaList);
                    //TempData["Toppings"] = JsonConvert.SerializeObject(ToppingsList);
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    HttpContext.Session.SetString("Toppings", JsonConvert.SerializeObject(ToppingsList));
                    TempData["Toppings"] = HttpContext.Session.GetString("Toppings");
                    TempData["Pizza"] = HttpContext.Session.GetString("Pizza");
                    TempData.Keep("Pizza");
                    TempData.Keep("Toppings");
                    return RedirectToAction("Details", "Users");
                }
            }
            else
            {
                total += _PRepo.Get((int)TempData.Peek("ID")).Price;

                if (HttpContext.Session.GetString("Pizza") != null)
                {
                    PizzaList = JsonConvert.DeserializeObject<Dictionary<string, Pizza>>(HttpContext.Session.GetString("Pizza"));
                    ToppingsList = JsonConvert.DeserializeObject<Dictionary<string, Toppings>>(HttpContext.Session.GetString("Toppings"));
                    foreach (var item in PizzaList.Keys)
                    {
                        if (PizzaList[item].ID == ID && !ToppingsList.ContainsKey(item))
                        {
                            _logger.LogInformation("Pizza Already Exists");
                             return RedirectToAction("Pizzas", "Users");
                        }
                    }
                    PizzaList.Add((PizzaList.Count + 1).ToString(), _PRepo.Get((int)TempData["ID"]));
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    ViewBag.Pizza = HttpContext.Session.GetString("Pizza");
                    TempData["Pizza"] = HttpContext.Session.GetString("Pizza");
                    TempData.Keep("Pizza");
                    return RedirectToAction("Details", "Users");
                }
                else
                {
                    PizzaList = new Dictionary<string, Pizza>();
                    PizzaList.Add((PizzaList.Count + 1).ToString(), _PRepo.Get((int)TempData["ID"]));
                    HttpContext.Session.SetString("Pizza", JsonConvert.SerializeObject(PizzaList));
                    ViewBag.Pizza = HttpContext.Session.GetString("Pizza");
                    TempData["Pizza"] = HttpContext.Session.GetString("Pizza");
                    TempData.Keep("Pizza");
                    return RedirectToAction("Details", "Users");

                }

            }


        }

        public IActionResult Details()
        {
             ViewBag.UserID=HttpContext.Session.GetString("UserID");
            _logger.LogInformation(total.ToString());
            PizzaList= JsonConvert.DeserializeObject<Dictionary<string, Pizza>>(HttpContext.Session.GetString("Pizza"));
            ToppingsList = JsonConvert.DeserializeObject<Dictionary<string, Toppings>>(HttpContext.Session.GetString("Toppings"));
            _logger.LogInformation("List pizza size"+PizzaList.Count.ToString());
            _logger.LogInformation("List Toppings Size"+ToppingsList.Count.ToString());
            return View();
        }
        public bool ValidateEmailAddress(string email)
        {
            bool match = false;
            try
            {
                regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                return match = regex.IsMatch(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return match;
            }
        }
        public bool ValidatePassword(string plainText)
        {
            bool match = false;
            try
            {
                regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");
                match = regex.IsMatch(plainText);
                return match;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return match;
            }

        }
        public static bool ValidatePhone(string phone)
        {
            bool match = false;
            try
            {
                return match = Regex.IsMatch(phone, "\\A[6-9][0-9]{8}\\z");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return match;
            }
        }

    }
}
