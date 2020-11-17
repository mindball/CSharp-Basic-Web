using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        
        public HttpResponse Login()
        {
            return this.View();
        }
                
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoLogin()
        {
            return this.View();
        }
    }
}
