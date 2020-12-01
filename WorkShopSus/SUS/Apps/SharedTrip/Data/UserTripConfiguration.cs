using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedTrip.Models;

namespace SharedTrip.Data
{
    public class UserTripConfiguration : IEntityTypeConfiguration<UserTrips>
    {
        public void Configure(EntityTypeBuilder<UserTrips> builder)
        {
            builder.HasKey(x => new { x.UserId, x.TripId });
        }

    }
}
