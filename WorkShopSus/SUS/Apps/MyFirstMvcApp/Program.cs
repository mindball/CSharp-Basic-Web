using SUS.HTTP;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            
            await server.StartAsync(8080);

        }

    }
}
