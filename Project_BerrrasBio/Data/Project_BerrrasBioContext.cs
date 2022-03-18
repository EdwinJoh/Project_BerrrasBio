#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_BerrrasBio.Models;

namespace Project_BerrrasBio.Data
{
    public class Project_BerrrasBioContext : DbContext
    {
        public Project_BerrrasBioContext (DbContextOptions<Project_BerrrasBioContext> options)
            : base(options)
        {
        }

        public DbSet<Project_BerrrasBio.Models.Booking> Booking { get; set; }

        public DbSet<Project_BerrrasBio.Models.Movie> Movie { get; set; }

        public DbSet<Project_BerrrasBio.Models.Salon> Salon { get; set; }

        public DbSet<Project_BerrrasBio.Models.Show> Show { get; set; }
    }
}
