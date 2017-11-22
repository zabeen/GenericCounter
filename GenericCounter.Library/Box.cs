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

    public class Box<T> : IBox
    {
        public int Count => _contents.Count;

        private List<T> _contents;

        public Box(IEnumerable<T> contents)
        {
            _contents = new List<T>(contents);
        }

        public void Empty()
        {
            _contents.Clear();
        }
    }
}
