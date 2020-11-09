using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class Route
    {
        public Route(string urlPath, Func<HttpRequest, HttpResponse> action)
        {
            this.UrlPath = urlPath;
            this.Action = action;
        }     

        public string UrlPath { get; set; }

        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
