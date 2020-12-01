using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;

namespace SharedTrip.App.Controllers
{
    public class HomeController : Controller
    { 
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}