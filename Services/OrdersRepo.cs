using Microsoft.EntityFrameworkCore;
using PizzaHut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Services
{
    public class OrdersRepo : IRepo<Orders>
    {
        private readonly PizzaHutContext _pizzaHutContext;

        public OrdersRepo(PizzaHutContext pizzaHutContext)
        {
            _pizzaHutContext = pizzaHutContext;
        }
        public Orders Add(Orders k)
        {
            try
            {
                _pizzaHutContext.Orders.Add(k);
                _pizzaHutContext.SaveChanges();
                return _pizzaHutContext.Orders.Where(e=>e.UserID==k.UserID).ToList()[_pizzaHutContext.Orders.Where(e => e.UserID == k.UserID).ToList().Count-1];
            }
            catch (DbUpdateConcurrencyException ducex)
            {
                Console.WriteLine(ducex.Message);
            }
            catch (DbUpdateException dbuex)
            {
                Console.WriteLine(dbuex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Orders Get(int ID)
        {
            throw new NotImplementedException();
        }
         
        public ICollection<Orders> GetAll()
        {
            throw new NotImplementedException();
        }

        public Orders Validate(Orders k)
        {
            throw new NotImplementedException();
        }

        public Orders Validate2(Orders k)
        {
            throw new NotImplementedException();
        }
    }
}
