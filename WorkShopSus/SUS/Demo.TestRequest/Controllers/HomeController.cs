using SIS.HTTP.DiffApproach.Requests.Contracts;
using SIS.HTTP.DiffApproach.Responses.Contracts;

namespace Demo.TestRequest.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Home(IHttpRequest httpRequest)
        {
            return this.View();
        }
    }
}
