using SIS.HTTP.DiffApproach.Enums;
using SIS.HTTP.DiffApproach.Requests.Contracts;
using SIS.HTTP.DiffApproach.Responses.Contracts;
using SIS.WebServer.DiffApproach.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.TestRequest
{
    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello world!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}
