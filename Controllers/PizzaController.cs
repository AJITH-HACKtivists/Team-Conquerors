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
        private ILogger<PizzaController> _logger;
        private readonly IRepo<Pizza> _PRepo;

        public PizzaController(ILogger<PizzaController> logger,IRepo<Pizza> PRepo)
        {
            _logger = logger;
            _PRepo = PRepo;
        }
        public IActionResult Index(int ID)
        {
            return View(_PRepo.GetAll());
        }
    }
}
