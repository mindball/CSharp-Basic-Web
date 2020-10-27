using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Codingame.Demo
{
    public class CPUBoundAsynchronous
    {
        public void DoSomethingSynchronous()
        {
            Console.WriteLine("Doing some synchronous work");
        }

        public async Task<float> CalculateTotalAfterTaxAsync(float value)
        {
            Console.WriteLine("Started CPU Bound asynchronous task on a background thread");
            var result = await Task.Run(() => value * 1.2f);
            Console.WriteLine($"Finished Task. Total of ${value} after tax of 20% is ${result} ");
            return result;
        }
    }
}
