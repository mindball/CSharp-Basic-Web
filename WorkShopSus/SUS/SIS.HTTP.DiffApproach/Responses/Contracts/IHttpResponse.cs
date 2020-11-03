
namespace SIS.HTTP.DiffApproach.Responses.Contracts
{
    using SIS.HTTP.DiffApproach.Cookies;
    using SIS.HTTP.DiffApproach.Enums;
    using SIS.HTTP.DiffApproach.Headers;
    using SIS.HTTP.DiffApproach.Headers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);
        void AddCookie(HttpCookie cookie);

        byte[] GetBytes();
    }
}
