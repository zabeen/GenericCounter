using GenericCounter.Library;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GenericCounter.Console
{
    class Program
    {
        static void Main(string[] args)
        {;
            WriteCounterCount("Loose Apples", CreateAppleCounter());
            WriteCounterCount("Loose Red Apples", CreateRedAppleCounter());
            WriteCounterCount("Cart", CreateCartCounter());
            WriteCounterCount("Boxed Apples", CreateBoxOfAppleCounter());
            WriteCounterCount("Box of ICountables", CreateBoxOfICountableCounter());
        
            System.Console.ReadLine();
        }

        static void WriteCounterCount(string counterName, ICounter counter)
        {
            System.Console.WriteLine($"{counterName} counter: {counter.Count()}");
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

        #region CreateCounters

        static ICounter<Apple> CreateAppleCounter()
        {
            var appleCounter = new Counter<Apple>();
            appleCounter.Add(new Apple());
            appleCounter.Add(new Apple());
            return appleCounter;
        }

        static ICounter<Apple> CreateRedAppleCounter()
        {
            var appleCounter = new Counter<Apple>(a => a.Colour.Equals(Color.Red));
            appleCounter.Add(new Apple(Color.Red));
            appleCounter.Add(new Apple());
            appleCounter.Add(new Apple(Color.Green));
            return appleCounter;
        }

        static ICounter<Cart> CreateCartCounter()
        {
            var oneApple = GetBoxOfApples(1);
            var twoApples = GetBoxOfApples(2);
            var threeApples = GetBoxOfApples(3);
            var fourApples = GetBoxOfApples(4);

            var cart1 = new Cart(new List<IBox>() { oneApple, twoApples });
            var cart2 = new Cart(new List<IBox>() { threeApples, fourApples });

            var cartCounter = new Counter<Cart>();
            cartCounter.Add(cart1);
            cartCounter.Add(cart2);

            return cartCounter;
        }

        static ICounter<Box<Apple>> CreateBoxOfAppleCounter()
        {
            var boxCounter = new Counter<Box<Apple>>();
            boxCounter.Add(GetBoxOfApples(15));
            boxCounter.Add(GetBoxOfApples(3));
            return boxCounter;
        }

        static ICounter<Box<ICountable>> CreateBoxOfICountableCounter()
        {
            var boxCounter = new Counter<Box<ICountable>>();
            boxCounter.Add(new Box<ICountable>(new List<ICountable>() { new Apple(), new Shoes() }));
            return boxCounter;
        }

        #endregion
    }
}
