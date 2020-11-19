using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SUS.MvcFramework;

namespace BattleCards.Data
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Role = IdentityRole.User;
            this.UsersCards = new List<UserCard>();
        }

        public virtual ICollection<UserCard> UsersCards { get; set; }
    }
}
