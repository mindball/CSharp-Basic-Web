using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleCards
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp(), 8000);
        }
    }
}
