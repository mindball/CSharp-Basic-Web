using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class Route
    {
        public Route(string urlPath, HttpMethod method, Func<HttpRequest, HttpResponse> action)
        {
            this.UrlPath = urlPath;
            this.Action = action;
            this.Method = method;
        }     

        public string UrlPath { get; set; }

        public Func<HttpRequest, HttpResponse> Action { get; set; }

        public HttpMethod Method { get; set; }
    }
}
