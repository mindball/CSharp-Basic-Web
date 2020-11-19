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
            if(this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }

            return this.View();
        }

        // GET /home/about
        [HttpGet("/about")]
        public HttpResponse About()
        {
            this.SignIn("niki");
            return this.View();
        }
    }
}
