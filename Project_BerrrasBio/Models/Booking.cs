using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Project_BerrrasBio.Models
{
    public partial class Booking
    {
        
        public int Id { get; set; }

        public int ShowId { get; set; }

        [Display(Name = "Number of seats")]
        [Range(1, 12, ErrorMessage = "Minimum: 1 Seat. Maximum 12 Seats")]
        public int NumOfSeats { get; set; }

        public virtual Show? shows { get; set; }
        
        
    }
}
