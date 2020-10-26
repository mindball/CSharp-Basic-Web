using System;
using System.Threading.Tasks;

namespace AsynAndAwait.AsyncVersion
{
    public  class Bacon
    {
        public async Task FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");

            Task.Delay(3000).Wait();

            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }

            Console.WriteLine("cooking the second side of bacon...");

            Task.Delay(3000).Wait();

            Console.WriteLine("Put bacon on plate");
        }
    }
}