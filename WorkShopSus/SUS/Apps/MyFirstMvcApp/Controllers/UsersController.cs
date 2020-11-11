using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }
        

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }

        [HttpPost(ActionName = "Login", Url = "")]
        public HttpResponse DoLogin(HttpRequest request)
        {
            return this.Redirect("/");
        }
    }
}
