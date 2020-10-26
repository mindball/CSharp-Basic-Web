using System;

namespace AsynAndAwait.SyncVersion
{
    public class Coffee
    {
        public Coffee()
        {
            this.PourCoffee();
        }
        public void PourCoffee()
        {
            Console.WriteLine("Pouring coffee");           
        }
    }
}