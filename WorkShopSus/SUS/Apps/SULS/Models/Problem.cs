using GlobalConstant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Problem
    {
        
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new List<Submission>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(Common.MaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(Common.MaxPoints)]
        public ushort Points { get; set; }


        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
