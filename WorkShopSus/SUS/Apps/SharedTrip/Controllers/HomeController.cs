using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;

namespace SharedTrip.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITripsService tripsService;

        public HomeController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {                
                return this.View("/Trips/All");
            }
            else
            {
                return this.View();
            }
        }
    }
}