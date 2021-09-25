using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class Pizza
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Speicality { get; set; }
        public string Crust { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public override string ToString()
        {
            return "Pizza ID"+ID+"\nPizza Name"+Name+"\nPrice"+Price;
        }
    }
}
