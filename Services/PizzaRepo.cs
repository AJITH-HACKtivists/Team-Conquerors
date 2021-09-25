using PizzaHut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Services
{
    public class PizzaRepo:IRepo<Pizza>
    {
        private readonly PizzaHutContext _pizzaHutContext;

        public PizzaRepo(PizzaHutContext pizzaHutContext)
        {
            _pizzaHutContext = pizzaHutContext;
        }
        public ICollection<Pizza> GetAll()
        {
            if (_pizzaHutContext.Pizza.ToList().Count > 0)
            {
                return _pizzaHutContext.Pizza.ToList();
            }
            else
                return null;
        }
        public Pizza Validate(Pizza pizza)
        {
            return null;
        }
        public Pizza Validate2(Pizza pizza)
        {
            return null;
        }
        public Pizza Add(Pizza pizza)
        {
            return null;
        }
        public Pizza Get(int ID)
        {
            if (_pizzaHutContext.Pizza.Where(e => e.ID == ID).Any())
            {
                return _pizzaHutContext.Pizza.First(e => e.ID == ID);
            }
            else
                return null;
        }
    }
}
