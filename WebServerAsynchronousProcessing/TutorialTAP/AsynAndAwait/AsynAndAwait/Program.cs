

namespace AsynAndAwait
{
    using AsynAndAwait.AsyncVersion;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            //TAPModel model = new TAPModel();

            //var value = model.GetUrlContentLengthAsync("https://dir.bg/");


            //synchronous code
            //SyncVersion.Coffee cup = new SyncVersion.Coffee();
            //Console.WriteLine("coffee is ready");

            //SyncVersion.Egg eggs = new SyncVersion.Egg(3);
            //Console.WriteLine("eggs are ready");

            //SyncVersion.Bacon bacon = new SyncVersion.Bacon(5);
            //Console.WriteLine("bacon is ready");

            //SyncVersion.Toast toast = new SyncVersion.Toast(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");
            //Console.WriteLine("Breakfast is ready!");


            /* asynchronous version
             * Don't block, await instead
             *
             * Start tasks concurrently
             * Composition with tasks
             * 
             * Await tasks efficiently
             * Task.WhenAll Method
             * 
            **/

            Console.Write(new string('-', 20));
            Console.Write(" Start tasks concurrently");
            Console.Write(new string('-', 20));
            Console.WriteLine();
            StartAsyncWork concurrently = new StartAsyncWork();
            await StartAsyncWorkConcurrentlyAsync(concurrently);

            Console.Write(new string('-', 20));
            Console.Write(" Start tasks Composition");
            Console.Write(new string('-', 20));
            Console.WriteLine();
            StartAsyncWork composition = new StartAsyncWork();
            await StartAsyncWorkCompositionAsync(composition);


            Console.Write(new string('-', 20));
            Console.Write(" Await tasks efficiently-Task.WhenAll Method");
            Console.Write(new string('-', 20));
            Console.WriteLine();

            StartAsyncWork efficiently = new StartAsyncWork();
            await StartAsyncWorkEfficientlyAsync(efficiently);            
        }

        public async static Task StartAsyncWorkEfficientlyAsync(StartAsyncWork efficiently)
        {
            var cup = efficiently.PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = efficiently.FryEggsAsync(2);
            var baconTask = efficiently.FryBaconAsync(3);
            var toastTask = efficiently.MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = efficiently.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        public async static Task StartAsyncWorkCompositionAsync(StartAsyncWork composition)
        {
            var cup = composition.PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = composition.FryEggsAsync(2);
            Task<Bacon> baconTask = composition.FryBaconAsync(3);
            Task<Toast> toastTask = composition.MakeToastWithButterAndJamAsync(2);

            var eggs = await eggsTask;
            Console.WriteLine("eggs are ready");

            var bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            var toast = await toastTask;
            Console.WriteLine("toast is ready");

            Juice oj = composition.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        public async static Task StartAsyncWorkConcurrentlyAsync(StartAsyncWork concurrently)
        {
            concurrently.PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = concurrently.FryEggsAsync(2);
            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready");

            Task<Bacon> baconTask = concurrently.FryBaconAsync(3);
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            Task<Toast> toastTask = concurrently.ToastBreadAsync(2);
            Toast toast = await toastTask;
            concurrently.ApplyButter(toast);
            concurrently.ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = concurrently.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

        }
    }
}

