using SIS.HTTP.DiffApproach.Cookies;
using SIS.HTTP.DiffApproach.Enums;
using SIS.HTTP.DiffApproach.Headers.Contracts;
using System.Collections.Generic;

namespace SIS.HTTP.DiffApproach.Requests.Contracts
{
    public interface IHttpRequest
    {
        string Path { get;  }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }

        IHttpCookieCollection Cookies { get; }
    }
}
