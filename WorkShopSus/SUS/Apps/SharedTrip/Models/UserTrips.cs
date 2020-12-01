using System;

namespace SharedTrip.Models
{
    public class UserTrips
    {
        public UserTrips()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string TripId { get; set; }

        public virtual Trip Trip { get; set; }
    }
}