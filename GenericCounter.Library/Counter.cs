using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCounter.Library
{
    public class Counter<T> where T : ICountable
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public int Count()
        {
            return _items.Sum(i => i.Count);
        }
    }
}
