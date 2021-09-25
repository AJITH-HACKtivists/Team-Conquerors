using Microsoft.EntityFrameworkCore;
using PizzaHut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Services
{
    public class UsersRepo:IRepo<Users>
    {
        private readonly PizzaHutContext _pizzaContext;

        public UsersRepo(PizzaHutContext pizzaContext)
        {
            _pizzaContext = pizzaContext;
        }
        public Users Validate(Users users)
        {
            Users user = null;
            if (_pizzaContext.Customers.Where(e => e.UserID == users.UserID && e.Password == users.Password).Any())
            {
                user = _pizzaContext.Customers.First(e => e.UserID == users.UserID && e.Password == users.Password);
                return user;
            }
            else
                return user;
        }
        public ICollection<Users> GetAll()
        {
            return null;
        }
        public Users Validate2(Users users)
        {
            Users user = null;
            if (_pizzaContext.Customers.Where(e => e.UserID == users.UserID).Any())
            {
                user = _pizzaContext.Customers.First(e => e.UserID == users.UserID && e.Password == users.Password);
                return user;
            }
            else
                return user;
        }
        public Users Add(Users users)
        {

            try
            {
                _pizzaContext.Customers.Add(users);
                _pizzaContext.SaveChanges();
                return _pizzaContext.Customers.First(e=>e.UserID==users.UserID && e.Password==users.Password);
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
        public Users Get(int ID)
        {
            return null;
        }
    }
}
