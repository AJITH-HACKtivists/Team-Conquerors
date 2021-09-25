using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class OrderDetails
    {
        [Key]
        public int ID { get; set; }
        public int Order_ID { get; set; }
        [ForeignKey("Order_ID")]
        public Orders Orders { get; set; }
        public int ToppingsID { get; set; }
        [ForeignKey("ToppingsID")]
        public Toppings Toppings { get; set; }

    }
}
