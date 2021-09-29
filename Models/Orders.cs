using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class Orders
    {
        [Key]
        public int Order_ID { get; set; }        
        public int Pizza_ID { get; set; }
        [ForeignKey("Pizza_ID")]
        public Pizza Pizza { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public Users Users { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
