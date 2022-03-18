using System;
using System.Collections.Generic;

namespace Project_BerrrasBio.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public int? NumOfSeats { get; set; }

        public virtual Movie? Movie { get; set; }
    }
}
