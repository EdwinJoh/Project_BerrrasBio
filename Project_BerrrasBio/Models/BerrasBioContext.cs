using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_BerrrasBio.Models
{
    public partial class BerrasBioContext : DbContext
    {
        public BerrasBioContext()
        {
        }

        public BerrasBioContext(DbContextOptions<BerrasBioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Salon> Salons { get; set; } = null!;
        public virtual DbSet<Show> Shows { get; set; } = null!;

      
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasIndex(e => e.MovieId, "fk");

                entity.HasIndex(e => e.Id, "pk");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_Bookings.MovieID");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoverUrl).HasMaxLength(200);

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Salon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasIndex(e => new { e.MovieId, e.SalonId }, "fk");

                entity.HasIndex(e => e.Id, "pk");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.ShowTime).HasColumnType("datetime");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_Shows.MovieID");

                entity.HasOne(d => d.Salon)
                    .WithMany()
                    .HasForeignKey(d => d.SalonId)
                    .HasConstraintName("FK_Shows.SalonId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
