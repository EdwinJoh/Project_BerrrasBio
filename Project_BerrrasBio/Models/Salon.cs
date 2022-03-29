using System;
using System.Collections.Generic;

namespace Project_BerrrasBio.Models
{
    public partial class Salon
    {
        /// <summary>
        /// Our property for our Salon object for out application
        /// </summary>
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Seats { get; set; }

        // Relationships
        public virtual ICollection<Show>? Shows { get; set; }
    }
}
