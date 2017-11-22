using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCounter.Library
{
    public class Cart : ICountable
    {
        public int Count => _boxes.Sum(b => b.Count);

        private List<IBox> _boxes;

        public Cart(IEnumerable<IBox> boxes)
        {
            _boxes = new List<IBox>(boxes);
        }
    }
}
