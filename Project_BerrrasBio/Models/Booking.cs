using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Project_BerrrasBio.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        
        public int ShowId { get; set; }
        
        [Display(Name ="Number of seats")]
        public int NumOfSeats { get; set; }

        public virtual Show? shows { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
