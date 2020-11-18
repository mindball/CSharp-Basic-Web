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
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";

            if (this.Request.Session.ContainsKey("about"))
            {
                viewModel.Message += " YOU WERE ON THE ABOUT PAGE!";
            }
            return this.View();
          
        }

        // GET /home/about
        [HttpGet("/about")]
        public HttpResponse About()
        {
            this.Request.Session["about"] = "yes";
            return this.View();
        }
    }
}
