using System;
using System.Threading.Tasks;

namespace AsynAndAwait.AsyncVersion
{
    public class Egg
    {

        public async Task FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");
        }
    }
}