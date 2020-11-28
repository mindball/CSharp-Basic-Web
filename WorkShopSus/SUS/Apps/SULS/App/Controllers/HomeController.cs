using Services;
using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if(this.IsUserSignedIn())
            {
                //DTO to view model how? resultAllSubmittedProblem -> HomePageProblemViewModel
                var resultAllSubmittedProblem = this.problemsService.GetAll();

                return this.View(resultAllSubmittedProblem, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }
    }
}