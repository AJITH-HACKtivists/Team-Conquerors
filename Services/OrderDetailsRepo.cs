using Microsoft.EntityFrameworkCore;
using PizzaHut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Services
{
    public class OrderDetailsRepo : IRepo<OrderDetails>
    {
        private readonly PizzaHutContext _pizzaHutContext;

        public OrderDetailsRepo(PizzaHutContext pizzaHutContext)
        {
            _pizzaHutContext = pizzaHutContext;
        }
        public OrderDetails Add(OrderDetails k)
        {
            try
            {
                _pizzaHutContext.OrderDetails.Add(k);
                _pizzaHutContext.SaveChanges();
                return _pizzaHutContext.OrderDetails.ToList()[_pizzaHutContext.Orders.ToList().Count - 1];
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

        public OrderDetails Get(int ID)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetails Validate(OrderDetails k)
        {
            throw new NotImplementedException();
        }

        public OrderDetails Validate2(OrderDetails k)
        {
            throw new NotImplementedException();
        }
    }
}
