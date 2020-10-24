using SIS.HTTP.DiffApproach.Enums;
using SIS.HTTP.DiffApproach.Headers;
using SIS.HTTP.DiffApproach.Requests;
using SIS.HTTP.DiffApproach.Responses;
using SIS.HTTP.DiffApproach.Responses.Contracts;
using SIS.WebServer.DiffApproach;
using SIS.WebServer.DiffApproach.Routing;
using System;
using System.Globalization;
using System.Text;

namespace Demo.TestRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get,
                "/",
                request => new HomeController().Index(request));

            Server server = new Server(8000, serverRoutingTable);

            server.Run();

        }
    }
}
