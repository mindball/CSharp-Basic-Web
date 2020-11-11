using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;
using System.Linq;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public HttpResponse IndexSlash(HttpRequest request)
        {
            return Index(request);
        }

        //another name of Index is Homepage
        public HttpResponse Index(HttpRequest request)
        {            
            return this.View();
        }

    }
}
