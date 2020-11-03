using Demo.TestRequest.Controllers;
using SIS.HTTP.DiffApproach.Enums;
using SIS.WebServer.DiffApproach;
using SIS.WebServer.DiffApproach.Routing;
using System.Threading.Tasks;

namespace Demo.TestRequest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get,
                "/",
                request => new HomeController().Home(request));

            Server server = new Server(8000, serverRoutingTable);

            await server.Run();

        }
    }
}
