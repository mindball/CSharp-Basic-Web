namespace App.Controllers
{
    using Services;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using SUS.MvcFramework.Attributes;

    public class ProblemsController : Controller
    {
        private IProblemsService problemService;

        public ProblemsController(IProblemsService problemService)
        {
            this.problemService = problemService;
        }

        ///Problems/Create
        ///

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if(!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if(string.IsNullOrEmpty(name) || name.Length < 5 || name.Length > 20)
            {
                return this.Error($"Problem name '{name}' must be bigger than 5 and less than 20 and not empty");
            }

            if(points < 50 || points > 300)
            {
                return this.Error("Point range must be 50 to 300");
            }

            this.problemService.Create(name, (ushort)points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var resultView = this.problemService.GetById(id);

            return this.View(resultView);
        }
    }
}
