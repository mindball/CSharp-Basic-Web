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

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {
            return this.Redirect("/");
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            // TODO: read data
            // TODO: check user
            // TODO: log user
            return this.Redirect("/");
        }


        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Only logged-in users can logout.");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
