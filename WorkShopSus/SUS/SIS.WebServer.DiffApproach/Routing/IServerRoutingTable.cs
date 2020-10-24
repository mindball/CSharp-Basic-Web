using SIS.HTTP.DiffApproach.Enums;
using SIS.HTTP.DiffApproach.Requests.Contracts;
using SIS.HTTP.DiffApproach.Responses.Contracts;
using System;

namespace SIS.WebServer.DiffApproach.Routing
{
    public interface IServerRoutingTable
    {
        void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func);

        bool Contains(HttpRequestMethod method, string path);

        Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path);
    }
}
