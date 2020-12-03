using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class HomePageTripViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        //auxiliary field ор Computed property
        public string DepartureTimeAsString => this.DepartureTime.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        // Computed property
        //Good practice: Get available data from DB (Seats and UsedSeat) then calculate AvailableSeats
        public int AvailableSeats => this.Seats - this.UsedSeats;

        public sbyte Seats { get; set; }

        public int UsedSeats { get; set; }
    }
}
