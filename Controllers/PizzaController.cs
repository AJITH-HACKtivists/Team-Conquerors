using Microsoft.AspNetCore.Mvc;
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
        private readonly IRepo<Pizza> _repo;

        public PizzaController(IRepo<Pizza> repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }
    }
}
