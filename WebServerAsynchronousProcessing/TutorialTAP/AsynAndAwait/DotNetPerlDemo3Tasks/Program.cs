using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetPerlDemo3Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call Task.Run and invoke Method1.
            // ... Then call Method2.
            //     Finally wait for Method2 to finish for terminating the program.

            ////ContinueWith
            //Task.Run(() => Method1()).ContinueWith(task => Method2()).Wait();
            //Console.WriteLine("Finish");

            //CancellationToken
            // Create CancellationTokenSource.
            var source = new CancellationTokenSource();
            // ... Get Token from source.
            CancellationToken token = source.Token;

            // Run the DoSomething method and pass it the CancellationToken.
            // ... Specify the CancellationToken in Task.Run.
            var task = Task.Run(() => DoSomething(token), token);

            // Wait a few moments.
            Thread.Sleep(900);

            // Cancel the task.
            // ... This affects the CancellationTokens in the source.
            Console.WriteLine("Main::Cancel");
            source.Cancel();

            // Wait more.
            Thread.Sleep(500);
        }

        private static void DoSomething(CancellationToken token)
        {
            // Do something important.
            for (int i = 0; i < 1000; i++)
            {
                // Wait a few moments.
                Thread.Sleep(100);
                // See if we are canceled from our CancellationTokenSource.
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Method1 canceled");
                    return;
                }
                Console.WriteLine($"Method1 running... {i}");
            }
        }

        private static void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("::Method 1::");
            }
        }

        private static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("::Method 2::");
            }
        }
    }
}
