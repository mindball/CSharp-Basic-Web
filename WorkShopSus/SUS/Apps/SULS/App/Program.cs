using SUS.MvcFramework;
using System.Threading.Tasks;

namespace App
{
    public class Program
    {
        public static async Task  Main()
        {
            await Host.CreateHostAsync(new StartUp(), 8000);
        }
    }
}
