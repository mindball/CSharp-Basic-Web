using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private ApplicationDbContext db;
        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.db.UsersTrips.Any(u => u.UserId == userId && u.TripId == tripId);
            if(userInTrip)
            {
                return false;
            }

            var userTrip = new UserTrips
            {
                TripId = tripId,
                UserId = userId,
            };

            this.db.UsersTrips.Add(userTrip);
            this.db.SaveChanges();
            return true;
        }

        public void Create(AddTripInputModel trip)
        {
            var newTrip = new Trip()
            {
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = DateTime.ParseExact(trip.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = trip.ImagePath,
                Seats = (sbyte)trip.Seats,
                Description = trip.Description
            };

            this.db.Trips.Add(newTrip);
            this.db.SaveChanges();
        }

        public IEnumerable<HomePageTripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new HomePageTripViewModel
            {
                DepartureTime = x.DepartureTime,
                EndPoint = x.EndPoint,
                StartPoint = x.StartPoint,
                Id = x.Id,
                Seats = x.Seats,
                UsedSeats = x.UserTrips.Count()
            }).ToList();

            return trips;
        }

        public TripDetailsViewModel GetDetails(string id)
        {
            var trip = this.db.Trips.Where(x => x.Id == id)
               .Select(x => new TripDetailsViewModel
               {
                   DepartureTime = x.DepartureTime,
                   Description = x.Description,
                   EndPoint = x.EndPoint,
                   Id = x.Id,
                   ImagePath = x.ImagePath,
                   Seats = x.Seats,
                   StartPoint = x.StartPoint,
                   UsedSeats = x.UserTrips.Count(),
               })
               .FirstOrDefault();

            return trip;
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db.Trips.Where(t => t.Id == tripId)
                .Select(t => new
                {
                    t.Seats,
                    TakenSeats = t.UserTrips.Count()
                }).FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;

            return availableSeats > 0;
        }
    }
}
