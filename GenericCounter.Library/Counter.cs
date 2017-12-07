using System;
using System.Collections.Generic;
using System.Linq;

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
        private Func<TCountable, bool> _shouldBeCounted = i => true;

        public Counter() { }

        public Counter(Func<TCountable, bool> shouldBeCounted)
        {
            _shouldBeCounted = shouldBeCounted;
        }

        public void Add(TCountable item)
        {
            _items.Add(item);
        }

        public int Count()
        {
            return _items.Where(_shouldBeCounted).Sum(i => i.Count);
        }
    }
}
