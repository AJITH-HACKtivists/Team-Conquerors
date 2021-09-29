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
                    TempData["CustID"] = users.ID;
                    TempData.Keep("CustID");
                    TempData["Address"] = users.Address;
                    TempData.Keep("Address");
                    ViewBag.UserID = users.UserID;
                    return RedirectToAction("Index", "Pizza");
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
                else 
                {
                    Users userss=_repo.Add(user);
                    if (userss!= null)
                    {
                        TempData["UserID"] = userss.UserID;
                        TempData.Keep("UserID");
                        TempData["CustID"]= userss.ID;
                        TempData.Keep("CustID");
                        TempData["Address"] = userss.Address;
                        TempData.Keep("Address");
                        HttpContext.Session.SetString("UserID", user.UserID);
                        ViewBag.Success = "Registeration Successfull";
                        return RedirectToAction("Index", "Pizza");
                    }

                    else
                    {
                        ViewBag.Error = "Some Error Occured";
                        return View();
                    }
                }
                

            }
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
