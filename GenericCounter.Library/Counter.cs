using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCounter.Library
{
    public interface ICounter
    {
        int Count();
    }

    public interface ICounter<in TCountable> : ICounter where TCountable : ICountable
    {
        void Add(TCountable item);
    }

    public class Counter<TCountable> : ICounter<TCountable> where TCountable : ICountable
    {
        private List<TCountable> _items = new List<TCountable>();

        public void Add(TCountable item)
        {
            _items.Add(item);
        }

        public int Count()
        {
            return _items.Sum(i => i.Count);
        }
    }
}
