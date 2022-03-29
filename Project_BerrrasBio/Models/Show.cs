using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_BerrrasBio.Models
{
    public partial class Show
    {
        
        public Show()
        {
            Bookings = new HashSet<Booking>();
        }

        /// <summary>
        /// Our property for our Show object for out application
        /// </summary>
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int SalonId { get; set; }
        public DateTime ShowTime { get; set; }
        public int? AvailableSeats { get; set; }

        [Display(Name = "Price per Ticket")]
        [DataType(DataType.Currency)]
        public int PricePerTicket { get; set; }

        // Relationships
        public virtual Movie? Movie { get; set; }
        public virtual Salon? Salon { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }


    }
}
