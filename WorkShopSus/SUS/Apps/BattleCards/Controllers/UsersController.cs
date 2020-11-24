using BattleCards.Services;
using BattleCards.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }
                
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(username, password);

            if(userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);
            return this.Redirect("/Cards/All");
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister(RegisterUserViewModel  registerUser)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (registerUser.Username == null || registerUser.Username.Length < 5 || registerUser.Username.Length > 20)
            {
                return this.Error("Invalid username. The username should be between 5 and 20 characters.");
            }

            if (!Regex.IsMatch(registerUser.Username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed.");
            }

            if (string.IsNullOrWhiteSpace(registerUser.Email) || !new EmailAddressAttribute().IsValid(registerUser.Email))
            {
                return this.Error("Invalid email.");
            }

            if (registerUser.Password == null || registerUser.Password.Length < 6 || registerUser.Password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (registerUser.Password != registerUser.ConfirmPassword)
            {
                return this.Error("Passwords should be the same.");
            }

            if (!this.usersService.IsUsernameAvailable(registerUser.Username))
            {
                return this.Error("Username already taken.");
            }

            if (!this.usersService.IsEmailAvailable(registerUser.Password))
            {
                return this.Error("Email already taken.");
            }

            this.usersService.CreateUser(registerUser.Username, registerUser.Email, registerUser.Password);
            return this.Redirect("/Users/Login");
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
