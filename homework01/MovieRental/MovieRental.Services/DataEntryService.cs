using Microsoft.EntityFrameworkCore;
using MovieRental.DataAccess;
using MovieRental.Domain.Enums;
using MovieRental.Domain.Models;

namespace MovieRental.Services
{
    public class DataEntryService
    {
        private readonly MovieRentalContext _context;

        public DataEntryService(MovieRentalContext context)
        {
            _context = context;
        }

        // ---------- USERS ----------
        public async Task<User> AddUserAsync(string fullName, int age, string cardNumber,
                                             SubscriptionType subscriptionType = SubscriptionType.None,
                                             bool isSubscriptionExpired = false)
        {
            // уникатен CardNumber?
            var exists = await _context.Users.AnyAsync(u => u.CardNumber == cardNumber);
            if (exists) throw new InvalidOperationException("Card number already exists.");

            var user = new User
            {
                FullName = fullName,
                Age = age,
                CardNumber = cardNumber,
                CreatedOn = DateTime.Now,
                SubscriptionType = subscriptionType,
                IsSubscriptionExpired = isSubscriptionExpired
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // ---------- MOVIES ----------
        public async Task<Movie> AddMovieAsync(string title, Genre genre, Language language,
                                               DateTime releaseDate, TimeSpan length,
                                               int ageRestriction, int quantity)
        {
            var movie = new Movie
            {
                Title = title,
                Genre = genre,
                Language = language,
                ReleaseDate = releaseDate,
                Length = length,
                AgeRestriction = ageRestriction,
                Quantity = quantity,
                IsAvailable = quantity > 0
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        // ---------- RENTALS (Rent) ----------
        // Напомена: ReturnedOn е nullable (DateTime?) во твојата шема.
        public async Task<Rental> RentMovieAsync(int userId, int movieId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId)
                       ?? throw new InvalidOperationException("User not found.");

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId)
                        ?? throw new InvalidOperationException("Movie not found.");

            if (movie.Quantity <= 0) throw new InvalidOperationException("Movie is not available.");

            // не дозволувај двојно рентање на ист филм без да биде вратен
            var hasActive = await _context.Rentals.AnyAsync(r =>
                r.UserId == userId && r.MovieId == movieId && r.ReturnedOn == null);

            if (hasActive)
                throw new InvalidOperationException("User already has an active rental for this movie.");

            var rental = new Rental
            {
                UserId = user.Id,
                MovieId = movie.Id,
                RentedOn = DateTime.Now,
                ReturnedOn = null
            };

            // ажурирај количина/достапност
            movie.Quantity -= 1;
            if (movie.Quantity <= 0) movie.IsAvailable = false;

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
            return rental;
        }

        // ---------- RETURNS ----------
        public async Task ReturnMovieAsync(int userId, int movieId)
        {
            var rental = await _context.Rentals
                .FirstOrDefaultAsync(r => r.UserId == userId && r.MovieId == movieId && r.ReturnedOn == null);

            if (rental == null) throw new InvalidOperationException("Active rental not found.");

            rental.ReturnedOn = DateTime.Now;

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie != null)
            {
                movie.Quantity += 1;
                movie.IsAvailable = true;
            }

            await _context.SaveChangesAsync();
        }

        // ---------- OPTIONAL: Seed пакет (примерски филмови) ----------
        public async Task SeedSampleMoviesAsync()
        {
            if (await _context.Movies.AnyAsync()) return;

            var list = new List<Movie>
            {
                new Movie { Title="Inception", Genre=Genre.SciFi, Language=Language.English, ReleaseDate=new DateTime(2010,7,16), Length=TimeSpan.FromMinutes(148), AgeRestriction=13, Quantity=5, IsAvailable=true },
                new Movie { Title="The Dark Knight", Genre=Genre.Action, Language=Language.English, ReleaseDate=new DateTime(2008,7,18), Length=TimeSpan.FromMinutes(152), AgeRestriction=13, Quantity=0, IsAvailable=false },
                new Movie { Title="Parasite", Genre=Genre.Drama, Language=Language.German /* прилагоди */, ReleaseDate=new DateTime(2019,5,30), Length=TimeSpan.FromMinutes(132), AgeRestriction=15, Quantity=3, IsAvailable=true },
            };

            _context.Movies.AddRange(list);
            await _context.SaveChangesAsync();
        }
    }
}
