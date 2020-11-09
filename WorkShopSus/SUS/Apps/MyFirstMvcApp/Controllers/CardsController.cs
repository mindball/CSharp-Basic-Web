using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add(HttpRequest httpRequest)
        {
            return this.View();
        }

        public HttpResponse All(HttpRequest httpRequest)
        {
            return this.View();
        }

        public HttpResponse Collection(HttpRequest httpRequest)
        {
            return this.View();
        }
    }
}
