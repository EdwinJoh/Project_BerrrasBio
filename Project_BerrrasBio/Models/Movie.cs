using System;
using System.Collections.Generic;

namespace Project_BerrrasBio.Models
{
    public partial class Movie
    {
        /// <summary>
        /// Our property for our movie object for out application
        /// </summary>
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public string Description { get; set; }

        // Relationships
        public ICollection<Show>? shows { get; set; }
    }
}
