using BattleCards.Data;
using BattleCards.ViewModels.Cards;
using SUS.HTTP;
using SUS.MvcFramework;
using SUS.MvcFramework.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        private readonly BattleCardDbContext db;

        public CardsController(BattleCardDbContext db)
        {
            this.db = db;
        }
        public HttpResponse Add()
        {
            if(!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd(AddCardInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }            

            if(this.Request.FormData["name"].Length < 5)
            {
                return this.Error("Name should be at least 5 characters long.");
            }

            this.db.Cards.Add(new Card
            {
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description,
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword
            });

            this.db.SaveChanges();

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cardsViewModel = this.GetCardViewModel();

            return this.View(cardsViewModel);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var currentUserCardsViewModel = this.db.UsersCards
                .Where(uc => uc.UserId == this.GetUserId())
                .Select(c => new CardViewModel
                {
                    Id = c.Card.Id,
                    Name = c.Card.Name,
                    Description = c.Card.Description,
                    Attack = c.Card.Attack,
                    Health = c.Card.Health,
                    ImageUrl = c.Card.ImageUrl,
                    Type = c.Card.Keyword
                })
                .ToList();                

            return this.View(currentUserCardsViewModel);
        }

        public HttpResponse AddToCollection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }           
           
            foreach (var card in this.Request.QueryData)
            {
                int cardId = int.Parse(card.Value);
                var userId = this.GetUserId();

                if (this.db.UsersCards
                    .Any(uc => uc.CardId == cardId && uc.UserId == userId))
                {
                    return this.Error("The curent user have this card");
                }

                this.db.UsersCards.Add(new UserCard()
                {
                    CardId = cardId,
                    UserId = userId
                });
            }

            db.SaveChanges();

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            foreach (var card in this.Request.QueryData)
            {
                int cardId = int.Parse(card.Value);
                var userId = this.GetUserId();
                
                var entity = this.db.UsersCards.FirstOrDefault(uc => uc.CardId == cardId && uc.UserId == userId);
                if(entity == null)
                {
                    return this.Error("The card not exitst");
                }

                this.db.UsersCards.Remove(entity);
                this.db.SaveChanges();
            }

            return this.Redirect("/Cards/Collection");
        }


        private ICollection<CardViewModel> GetCardViewModel()
        {
            return this.db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword
            }).ToList();            
        }
    }
}
