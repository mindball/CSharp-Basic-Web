using SUS.HTTP;
using SUS.MvcFramework;
using System.Linq;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {

        //another name of Index is Homepage
        public HttpResponse Index(HttpRequest request)
        {            
            return this.View();
        }

    }
}
