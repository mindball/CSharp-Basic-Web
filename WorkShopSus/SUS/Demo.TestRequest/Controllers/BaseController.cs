using SIS.HTTP.DiffApproach.Cookies;
using SIS.HTTP.DiffApproach.Enums;
using SIS.HTTP.DiffApproach.Responses.Contracts;
using SIS.WebServer.DiffApproach.Result;
using System.IO;
using System.Runtime.CompilerServices;

namespace Demo.TestRequest.Controllers
{
    public abstract class BaseController
    {
        public IHttpResponse View([CallerMemberName] string view = null)
        {
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;

            string viewContent = File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");

            HtmlResult htmlResult = new HtmlResult(viewContent, HttpResponseStatusCode.Ok);

            htmlResult.Cookies.AddCookie(new HttpCookie("lang", "en"));

            return htmlResult;
        }
    }
}
