using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SUS.MvcFramework;

namespace BattleCards.Data
{
    public class User : UserIdentity
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UsersCards = new List<UserCard>();
        }


        public virtual ICollection<UserCard> UsersCards { get; set; }
    }
}
