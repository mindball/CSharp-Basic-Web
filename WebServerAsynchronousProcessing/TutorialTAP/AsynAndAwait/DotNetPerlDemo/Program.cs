using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace DotNetPerlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1: start the HandleFile method.
            Task<int> task = HandleFileAsync();

            // Control returns here before HandleFileAsync returns.
            // ... Prompt the user.
            Console.WriteLine("Please be patiently while I do something important.");

            // Do something at the same time as the file is being read.
            string line = Console.ReadLine();
            Console.WriteLine("You entered (asynchronous logic): " + line);

            // Part 3: wait for the HandleFile task to complete.
            // ... Display its results.
            task.Wait();     
            
            var x = task.Result;
            Console.WriteLine("Count: " + x);

            Console.WriteLine("[DONE]");
            Console.ReadLine();

        }

        static async Task<int> HandleFileAsync()
        {
            // Part 1: start the HandleFile method.
            string filePath = @"enable.txt";

            // Part 2: status messages and long-running calculations.
            Console.WriteLine("HandleFile enter");
            int count = 0;

            using StreamReader reader = new StreamReader(filePath);

            string v = await reader.ReadToEndAsync();
            //....Process the file data somehow.

            count += v.Length;

            //.. A slow-running computation
            // Dummy code.
            for (int i = 0; i < 10000; i++)
            {
                int x = v.GetHashCode();
                if (x == 0)
                {
                    count--;
                }
            }

            Console.WriteLine("HandleFile exit");
            return count;
        }
    }
}
