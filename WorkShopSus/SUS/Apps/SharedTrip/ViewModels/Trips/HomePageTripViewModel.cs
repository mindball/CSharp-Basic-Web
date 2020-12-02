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

        public string DepartureTimeAsString => this.DepartureTime.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        public int AvailableSeats => this.Seats - this.UsedSeats;

        public sbyte Seats { get; set; }

        public int UsedSeats { get; set; }
    }
}
