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
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly IRepo<Pizza> _repo;

        public PizzaController(IRepo<Pizza> repo,ILogger<PizzaController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index(string UserID)
        {
            _logger.LogInformation(TempData["UserID"].ToString());
            TempData["User"] = TempData["UserID"];
            return View(_repo.GetAll());
        }
    }
}
