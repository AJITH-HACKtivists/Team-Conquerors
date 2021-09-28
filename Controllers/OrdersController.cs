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
    public class OrdersController : Controller
    {
        private readonly IRepo<Orders> _repo;
        private readonly IRepo<Pizza> _Prepo;
        private readonly ILogger<OrdersController> _logger;
        private readonly IRepo<OrderDetails> _repoo;
        Dictionary<string, Pizza> PizzaList;
        Dictionary<string, Toppings> ToppingsList;
        public OrdersController(ILogger<OrdersController> logger,IRepo<Orders> repo,IRepo<Pizza> Prepo,IRepo<OrderDetails> repoo)
        {
            _repo = repo;
            _Prepo = Prepo;
            _logger = logger;
            _repoo = repoo;
        }
        public IActionResult Index()
        {
            PlaceOrders();
           
            return View();
        }
        public void PlaceOrders()
        {
            Orders order;
            PizzaList = JsonConvert.DeserializeObject<Dictionary<string, Pizza>>(HttpContext.Session.GetString("Pizza"));
            ToppingsList= JsonConvert.DeserializeObject<Dictionary<string, Toppings>>(HttpContext.Session.GetString("Toppings"));

            foreach (var item in PizzaList.Keys)
            {
                double subTotal = 0;
               
                if(ToppingsList!=null && ToppingsList.ContainsKey(item))
                {
                    subTotal += PizzaList[item].Price + ToppingsList[item].Price;
                    order = new Orders() { Pizza_ID = PizzaList[item].ID, Price = subTotal, OrderDate = DateTime.Now, UserID = Convert.ToInt32(TempData.Peek("CustID")) };
                    Orders orders = _repo.Add(order);
                    if (orders != null)
                    {
                        OrderDetails details = new OrderDetails() { ToppingsID = ToppingsList[item].ID, Order_ID = orders.Order_ID };
                        if (_repoo.Add(details) != null)
                        {
                            _logger.LogInformation("Order Successfull");
                        }
                    }
                }
                else 
                {
                    order = new Orders() { Pizza_ID = PizzaList[item].ID, Price = PizzaList[item].Price, OrderDate = DateTime.Now, UserID = Convert.ToInt32(TempData.Peek("CustID")) };
                    Orders orders = _repo.Add(order);
                    if (orders != null)
                      _logger.LogInformation("Order places Successfully");
                }
            }
        }
    }
}
