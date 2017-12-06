using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCounter.Library
{
    public interface IBox : ICountable
    {
        void Empty();
    }

    public class Box<TCountable> : IBox where TCountable : ICountable
    {
        public int Count => _contents.Sum(c => c.Count);

        private List<TCountable> _contents;

        public Box(IEnumerable<TCountable> contents)
        {
            _contents = new List<TCountable>(contents);
        }

        public void Empty()
        {
            _contents.Clear();
        }
    }
}
