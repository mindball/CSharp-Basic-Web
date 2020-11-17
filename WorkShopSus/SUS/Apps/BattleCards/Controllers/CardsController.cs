using BattleCards.Data;
using MyFirstMvcApp.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            var dbContext = new BattleCardDbContext();
            dbContext.Cards.Add(new Card
            {
                Attack = int.Parse(this.Request.FormData["attack"]),
                Health = int.Parse(this.Request.FormData["health"]),
                Description = this.Request.FormData["description"],
                Name = this.Request.FormData["name"],
                ImageUrl = this.Request.FormData["image"],
                Keyword = this.Request.FormData["keyword"]
            });

            dbContext.SaveChanges();

            return this.Redirect("/");
        }
        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}
