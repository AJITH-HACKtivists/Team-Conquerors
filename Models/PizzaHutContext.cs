using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class PizzaHutContext:DbContext
    {
        public PizzaHutContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Users> Customers { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Users>().HasData(
               new Users() {ID=101, Name = "Ajith", UserID = "am9452197@gmail.com", Password = "Ajithama@19", Phone = "8971950713", Address = "#12/33 Jp Nagar 7th phase Putenahalli bangalore-560078" },

                new Users() {ID=102, Name = "Lohit", UserID = "lohit01091999@gmail.com", Password = "Lohit@99", Phone = "8310085985", Address = "#113 Attibele sarjapura bangalore-56125" }
               );
            modelBuilder.Entity<Pizza>().HasData(
               new Pizza() {ID=1001,Name="Veg Loaded",Price=199,Speicality="with Pepse",Crust="Fresh Pan Pizza",Description= "Peppy Paneer Cheese Burst Topped with Extra Cheese",Images="/images/pizza-1.jpg"},
                new Pizza() { ID = 1002, Name = "Peppy Paneer Pizza", Price = 299, Speicality = "with extra toppings", Crust = "Fresh Pan Pizza", Description = "Peppy Paneer Cheese Burst Topped with Extra Cheese", Images = "/images/pizza-2.jpg" },
                new Pizza() { ID = 1003, Name = "Peper Chicken", Price = 199, Speicality = "with Pepse", Crust = "Fresh Pan Pizza", Description = "Mashroon Topped", Images = "/images/pizza-3.jpg" },
                 new Pizza() { ID = 1004, Name = "Non Veg Loaded", Price = 299, Speicality = "with Pepse", Crust = "Fresh Pan Pizza", Description = "Peppy Paneer Cheese Burst Topped with Extra Cheese", Images = "/images/pizza-4.jpg" }
                );
            modelBuilder.Entity<Toppings>().HasData(
                new Toppings() {ID=201,Name="Tomato",Price=99 },
                new Toppings() { ID = 202, Name = "Cheese", Price = 89 },
                new Toppings() { ID = 203, Name = "Onion", Price = 100 }
                );
        }
    }
}
