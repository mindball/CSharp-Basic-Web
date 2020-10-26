using System;
using System.Threading.Tasks;

namespace AsynAndAwait.AsyncVersion
{
    public class Coffee
    {
        public async Task PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
        }
    }
}