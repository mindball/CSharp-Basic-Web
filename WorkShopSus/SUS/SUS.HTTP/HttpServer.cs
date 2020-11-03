using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        IDictionary<string, Func<HttpRequest, HttpResponse>>
            routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();

            while (true)
            {
                var tcpClient = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            try
            {
                using NetworkStream stream = tcpClient.GetStream();

                var data = new List<byte>();
                int position = 0;

                byte[] buffer = new byte[HttpConstants.BufferSize]; //chunk

                while (true)
                {
                    int count =
                            await stream.ReadAsync(buffer, position, buffer.Length);
                    position += count;

                    if (count < buffer.Length)
                    {
                        var partialBuffer = new byte[count];
                        Array.Copy(buffer, partialBuffer, count);

                        data.AddRange(partialBuffer);
                        break;
                    }
                    else
                    {
                        data.AddRange(buffer);
                    }
                }

                // byte[] => string (text)
                var requestAsString = Encoding.UTF8.GetString(data.ToArray());
                var request = new HttpRequest(requestAsString);
                PrintRequest(request);

                Console.WriteLine($"{request.Method} {request.Path} => {request.Headers.Count} headers");

                HttpResponse response;
                if (this.routeTable.ContainsKey(request.Path))
                {
                    var action = this.routeTable[request.Path];
                    response = action(request);
                }
                else
                {
                    //Not found
                    response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
                }

                response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
                {
                    HttpOnly = true,
                    MaxAge = 60 * 24 * 60 * 60
                });

                response.Headers.Add(new Header("Server", "SUS Server 1.0"));
                var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());
                await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                await stream.WriteAsync(response.Body, 0, response.Body.Length);

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void PrintRequest(HttpRequest request)
        {
            Console.WriteLine($"Method: {request.Method}; Path: {request.Path}");
            foreach (var header in request.Headers)
            {
                Console.WriteLine(header.ToString());
            }

            foreach (var cookie in request.Cookies)
            {
                Console.WriteLine(cookie.ToString());
            }

        }

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (this.routeTable.ContainsKey(path))
            {
                this.routeTable[path] = action;
            }
            else
            {
                this.routeTable.Add(path, action);
            }
        }
    }
}




    

