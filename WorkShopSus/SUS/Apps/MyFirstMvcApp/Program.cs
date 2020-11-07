using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            server.AddRoute("/", new HomeController().Index);
            //Example of store function()
            server.AddRoute("/niki", (httpRequest) =>
            {
                return new HttpResponse("text/html", new byte[] { 0x56, 0x57 });
            });

            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);

            server.AddRoute("/about", new HomeController().About);
            server.AddRoute("/users/login", new UserControleer().Login);
            server.AddRoute("/users/register", new UserControleer().Register);

            await server.StartAsync(8080);
        }
    }
}
