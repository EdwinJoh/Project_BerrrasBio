using System;
using System.Collections.Generic;

namespace Project_BerrrasBio.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CoverUrl { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
