using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Data
{
    public class BattleCardDbContext : DbContext
    {
        public  BattleCardDbContext()
        {
        }

        public BattleCardDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCard> UsersCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new UserCardConfiguration());
        }
    }
}
