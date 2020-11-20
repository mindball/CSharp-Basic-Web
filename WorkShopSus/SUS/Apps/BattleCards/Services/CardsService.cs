using BattleCards.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private BattleCardDbContext db;

        public CardsService()
        {
            this.db = new BattleCardDbContext();
        }
        public void AddCard()
        {
            throw new NotImplementedException();
        }
    }
}
