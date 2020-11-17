using MyFirstMvcApp.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;
using System;
using System.Linq;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {           
            return this.View();
          
        }

        // GET /home/about
        [HttpGet("/about")]
        public HttpResponse About()
        {
            return this.View();
        }
    }
}
