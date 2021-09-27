using PizzaHut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Services
{
    public class ToppingsRepo:IRepo<Toppings>
    {
      
        private readonly PizzaHutContext _pizzaHutContext;

        public ToppingsRepo(PizzaHutContext pizzaHutContext)
        {
            _pizzaHutContext = pizzaHutContext;
        }
        public ICollection<Toppings> GetAll()
        {
            if (_pizzaHutContext.Toppings.ToList().Count > 0)
            {
                return _pizzaHutContext.Toppings.ToList();
            }
            else
                return null;
        }
        public Toppings Validate(Toppings toppings)
        {
            return null;
        }
        public Toppings Validate2(Toppings toppings)
        {
            return null;
        }
        public Toppings Add(Toppings toppings)
        {
            return null;
        }
        public Toppings Get(int ID)
        {
            if (_pizzaHutContext.Toppings.Where(e => e.ID == ID).Any())
            {
                return _pizzaHutContext.Toppings.FirstOrDefault(e => e.ID == ID);
            }
            else
                return null;
        }
    }
}

