namespace App.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    using App.ViewModels;
    using App.ViewModels.Users;
    using Services;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using SUS.MvcFramework.Attributes;

    public class UsersController : Controller
    {
        private IUsersService userService;
       
        public UsersController(IUsersService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Register()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost()]
        public HttpResponse Register(RegisterInputViewModel view)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if(string.IsNullOrEmpty(view.Username) || view.Username.Length < 5 || view.Username.Length > 20)
            {
                return this.Error("username must be bigger from 5 and not empty!");
            }

            if (!Regex.IsMatch(view.Username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed.");
            }

            if (string.IsNullOrWhiteSpace(view.Email) || !new EmailAddressAttribute().IsValid(view.Email))
            {
                return this.Error("Invalid email.");
            }

            if (view.Password == null || view.Password.Length < 6 || view.Password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (view.Password != view.ConfirmPassword)
            {
                return this.Error("Passwords should be the same.");
            }

            this.userService.CreateUser(view.Username, view.Email, view.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if(string.IsNullOrEmpty(username) ||  string.IsNullOrEmpty(password))
            {
                return this.Error("Field username or password must be not emtpy");
            }

            var user = this.userService.GetUserId(username, password);

            if(string.IsNullOrEmpty(user))
            {
                return this.Error($"The current {username} doesnt exist");
            }

            this.SignIn(user);

            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}