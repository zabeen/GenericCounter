using System.Drawing;

namespace GenericCounter.Library
{

    public class Apple : ICountable
    {
        public int Count => _count;
        public Color Colour => _colour;

        private int _count = 1;
        private Color _colour = Color.Empty;

        public Apple() { }

        public Apple(Color colour)
        {
            _colour = colour;
        }
    }
}
