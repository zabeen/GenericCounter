using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCounter.Library;

namespace GenericCounter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteCounterCount("Apple", CreateAppleCounter());
            WriteCounterCount("Cart", CreateCartCounter());

            System.Console.ReadLine();
        }

        static void WriteCounterCount(string counterName, Counter<ICountable> counter)
        {
            System.Console.WriteLine($"{counterName} counter: {counter.Count()}");
        }

        static Counter<ICountable> CreateAppleCounter()
        {
            var appleCounter = new Counter<ICountable>();
            appleCounter.Add(new Apple());
            appleCounter.Add(new Apple());
            return appleCounter;
        }

        static Counter<ICountable> CreateCartCounter()
        {
            var oneApple = GetBoxOfApples(1);
            var twoApples = GetBoxOfApples(2);
            var threeApples = GetBoxOfApples(3);
            var fourApples = GetBoxOfApples(4);

            var cart1 = new Cart(new List<IBox>() { oneApple, twoApples });
            var cart2 = new Cart(new List<IBox>() { threeApples, fourApples });

            var cartCounter = new Counter<ICountable>();
            cartCounter.Add(cart1);
            cartCounter.Add(cart2);

            return cartCounter;
        }

        static Box<Apple> GetBoxOfApples(int numberOfApples)
        {
            var apples = new List<Apple>();

            for (int i = 0; i < numberOfApples; i++)
            {
                apples.Add(new Apple());
            }

            return new Box<Apple>(apples);
        }
    }
}
