using System;
using System.Threading.Tasks;

namespace AsynAndAwait.SyncVersion
{
    public class Toast
    {
        public Toast(int slices)
        {
            this.ToastBread(slices);
        }

        public void ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");
        }
    }
}