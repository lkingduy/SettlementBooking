using SettlementBookingSystem.Application.Bookings.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace SettlementBookingSystem.Application.Bookings.Dtos
{
    public static class DB
    {
        public static List<BookingDb> bookings = new List<BookingDb>();
        public static TimeSpan GetTimeSpan(string time) {
            return DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay;
        }
    }

    public class BookingDb {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BookingTime { get; set; }
    }
}