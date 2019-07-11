using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("complete!");
            Console.Read();
        }

        static async void Test()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            
            Task<Egg> eggTask = FryEggs(5);
            Egg eggs = await eggTask;
            Console.WriteLine("eggs are ready");
            Task<Bacon> baconTask = FryBacon(3);
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static Juice PourOJ()
        {
            throw new NotImplementedException();
        }

        private static Task<Toast> ToastBread(int i)
        {
           return Task.Run(()=>
           {
               Console.WriteLine("processing Toast...."); 
                Thread.Sleep(i);
                 return new Toast();
           }
               );
        }

        private static Task<Bacon> FryBacon(int i)
        {
            return Task.Run(()=>
                {
                    Console.WriteLine("processing Bacon...."); 
                    Thread.Sleep(i);
                    return new Bacon();
                }
            );
        }

        private static Task<Egg> FryEggs(int i)
        {
            return Task.Run(()=>
                {
                    Console.WriteLine("processing egg...."); 
                    Thread.Sleep(i);
                    return new Egg();
                }
            );
        }

        private static Coffee PourCoffee()
        {
              Thread.Sleep(1);
              return new Coffee();
        }

        private static void ApplyJam(Toast toast)
        {
            throw new NotImplementedException();
        }

        private static void ApplyButter(Toast toast)
        {
            throw new NotImplementedException();
        }
    }

    internal class Juice
    {
    }

    internal class Toast
    {
    }

    internal class Bacon
    {
    }

    internal class Egg
    {
    }

    internal class Coffee
    {
    }
}