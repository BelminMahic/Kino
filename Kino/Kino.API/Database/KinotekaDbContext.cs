using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class KinotekaDbContext : DbContext
    {
        public KinotekaDbContext(DbContextOptions<KinotekaDbContext> options)
          : base(options)
        {

        }

        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Auditorium> Auditorium { get; set; }
        public DbSet<MovieSeat> MovieSeat { get; set; }
        public DbSet<PromoMaterial> PromoMaterial { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserMovieRating> UserMovieRating { get; set; }

        public DbSet<Role> Role { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Screening> Screening { get; set; }
        public DbSet<SeatReservation> SeatReservation { get; set; }



    }
}
