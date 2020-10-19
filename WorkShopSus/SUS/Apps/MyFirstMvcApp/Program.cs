using System;
using System.Net;

namespace MyFirstMvcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpServer();

            server.Start(80);

            server.AddRoute("/", (request) =>
            {
                return new HttpResponseHeader();
            });



            server.AddRoute("/", HomePage);

            server.AddRoute("/about", About);

            server.AddRoute("/users/login", Login);

        }

        static HttpResponseHeader HomePage(HttpRequestHeader request)
        {

        }

        static HttpResponseHeader About(HttpRequestHeader request)
        {

        }

        static HttpResponseHeader Login(HttpRequestHeader request)
        {

        }
    }
}
