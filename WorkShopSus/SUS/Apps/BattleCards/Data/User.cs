using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data
{
    public class User 
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UsersCards = new List<UserCard>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Emal { get; set; }

        [Required]        
        public string Password { get; set; }

        public virtual ICollection<UserCard> UsersCards { get; set; }
    }
}
