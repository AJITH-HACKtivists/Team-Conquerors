using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class ViewModel
    {
        public Pizza pizza { get; set; }
        public ICollection<Toppings> Toppings{get; set;}
    }
}
