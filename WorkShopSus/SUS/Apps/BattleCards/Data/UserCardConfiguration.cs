using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BattleCards.Data
{
    internal class UserCardConfiguration : IEntityTypeConfiguration<UserCard>
    {
        public void Configure(EntityTypeBuilder<UserCard> builder)
        {
            builder.HasKey(x => new { x.UserId, x.CardId });
        }
    }
}