using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class Users
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        [Required]
        public string UserID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
