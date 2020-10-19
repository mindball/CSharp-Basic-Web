using System;
using System.Collections.Generic;
using System.Net;
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

            while(true)
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

                while(true)
                {
                    int count =
                            await stream.ReadAsync(buffer, position, buffer.Length);
                    position += count;

                    //
                    if(count < buffer.Length)
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

                var requestAsString = Encoding.UTF8.GetString(data.ToArray());
                var request = new HttpRequest(requestAsString);
                PrintRequest(request);

                Console.WriteLine($"{request.Method} {request.Path} => {request.Headers.Count} headers");

                // byte[] => string (text)
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
    }
}
