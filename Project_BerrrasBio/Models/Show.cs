using System;
using System.Collections.Generic;

namespace Project_BerrrasBio.Models
{
    public partial class Show
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public int? SalonId { get; set; }
        public DateTime? ShowTime { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual Salon? Salon { get; set; }
        public virtual IEnumerable<Booking>? Booking { get; set; }
    }
}
