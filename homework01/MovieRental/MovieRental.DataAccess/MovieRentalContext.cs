using Microsoft.EntityFrameworkCore;
using MovieRental.Domain.Models;

namespace MovieRental.DataAccess
{
    public class MovieRentalContext : DbContext
    {
        public MovieRentalContext(DbContextOptions<MovieRentalContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Cast> Casts { get; set; }
    }
}
