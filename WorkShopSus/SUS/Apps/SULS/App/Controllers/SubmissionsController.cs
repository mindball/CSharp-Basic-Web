using App.ViewModels.Submissions;
using Services;
using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;

namespace App.Controllers
{
    public class SubmissionsController : Controller
    {
        private IProblemsService problemsService;
        private ISubmissionsService submissionService;

        public SubmissionsController(IProblemsService problemsService,
            ISubmissionsService submissionService)
        {
            this.problemsService = problemsService;
            this.submissionService = submissionService;
        }

        public HttpResponse Create(string id)
        {
            if(!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateViewModel
            {
                ProblemId = id,
                Name = this.problemsService.GetNameById(id),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters long.");
            }

            var userId = this.GetUserId();

            this.submissionService.Create(problemId, this.GetUserId(), code);

            return this.Redirect("/");
        }
    }
}
