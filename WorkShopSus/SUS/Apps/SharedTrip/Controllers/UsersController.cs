using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        IUsersService userService;

        public UsersController(IUsersService userService)
        {
            this.userService = userService;
        }


        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        //Users/Register
        [HttpPost]
         public HttpResponse Register(RegisterInputModel view)
        {
            if(this.IsUserSignedIn())
            {
                this.Redirect("/");
            }

            if(string.IsNullOrEmpty(view.Username) || view.Username.Length < 5 || view.Username.Length > 20)
            {
                return this.Error("Username has not empty or username len must be in range (5 - 20)");
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
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return this.Error("Field username or password must be not emtpy");
            }

            var userId = this.userService.GetUserId(username, password);

            if(string.IsNullOrEmpty(userId))
            {
                return this.Error("Wrong username or password");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

    }
}
