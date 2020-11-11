using SUS.HTTP;
using SUS.MvcFramework;
using System;


namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public  HttpResponse CustomJs(HttpRequest request)
        {
            //
            return this.File("wwwroot/js/custom.js", "text/javascript");
        }

        public HttpResponse Favicon(HttpRequest request)
        {
            return this.File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
        }

        public HttpResponse BootstrapCss(HttpRequest request)
        {
            return this.File("wwwroot/css/bootstrap.min.css", "text/css");
        }

        public HttpResponse CustomCss(HttpRequest request)
        {
            return this.File("wwwroot/css/custom.css", "text/css");
        }

        public HttpResponse BootstrapJs(HttpRequest request)
        {
            return this.File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
        }
    }
}
