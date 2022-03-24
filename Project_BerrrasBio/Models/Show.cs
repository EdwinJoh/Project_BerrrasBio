using System;
using System.Collections.Generic;

namespace Project_BerrrasBio.Models
{
    public partial class Show 
    {
        public Show()
        {
            Bookings = new HashSet<Booking>();
        }
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int SalonId { get; set; }
        public DateTime ShowTime { get; set; }
        public int? AvailableSeats { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual Salon? Salon { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }

       
    }
}
