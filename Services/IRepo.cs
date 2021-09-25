using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Services
{
    public interface IRepo<K>
    {
        public K Validate(K k);
        public K Validate2(K k);
        public K Add(K k);
        public ICollection<K> GetAll();
        public K Get(int ID);
    }
}
