

namespace AsynAndAwait
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static async void Main(string[] args)
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


            //asynchronous version
            //Don't block, await instead

            await ASyncVersionAsync();
        }

        static async Task ASyncVersionAsync()
        {
            AsyncVersion.Coffee cup = new AsyncVersion.Coffee();
            await cup.PourCoffee();
            Console.WriteLine("coffee is ready");

            AsyncVersion.Egg eggs = new AsyncVersion.Egg();
            AsyncVersion.Bacon bacon = new AsyncVersion.Bacon();
            AsyncVersion.Toast toast = new AsyncVersion.Toast();
            AsyncVersion.Juice oj = new AsyncVersion.Juice();

            await eggs.FryEggsAsync(3);
            Console.WriteLine("eggs are ready");

            await bacon.FryBaconAsync(5);
            Console.WriteLine("bacon is ready");

            await toast.ToastBread(2);
            await toast.ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            await oj.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static void ApplyJam(SyncVersion.Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(SyncVersion.Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static void ApplyJam(AsyncVersion.Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(AsyncVersion.Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

    }
}

