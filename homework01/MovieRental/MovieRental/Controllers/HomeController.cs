using Microsoft.AspNetCore.Mvc;
using MovieRental.DataAccess;
using MovieRental.Domain.Models;
using System;
using System.Linq;

namespace MovieRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieRentalContext _context;

        public HomeController(MovieRentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Index", "Login");

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);
            ViewBag.LoggedInUser = user;

            var movies = _context.Movies.ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Index", "Login");

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);
            ViewBag.LoggedInUser = user;

            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();

            bool hasActiveRental = _context.Rentals.Any(r =>
                r.MovieId == id &&
                r.UserId == user.Id &&
                r.ReturnedOn == null);

            ViewBag.HasActiveRental = hasActiveRental;

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rent(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Index", "Login");

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);
            if (user == null)
                return RedirectToAction("Index", "Login");

            var existingRental = _context.Rentals.FirstOrDefault(r =>
                r.MovieId == id && r.UserId == user.Id && r.ReturnedOn == null);

            if (existingRental != null)
            {
                TempData["Error"] = "You have already rented this movie. Please return it before renting again.";
                return RedirectToAction("Details", new { id });
            }

            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();

            if (movie.Quantity <= 0)
            {
                TempData["Error"] = "This movie is not available.";
                return RedirectToAction("Details", new { id });
            }

            var rental = new Rental
            {
                MovieId = movie.Id,
                UserId = user.Id,
                RentedOn = DateTime.Now,
                ReturnedOn = null
            };

            movie.Quantity -= 1;
            if (movie.Quantity <= 0) movie.IsAvailable = false;

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            TempData["Success"] = "Movie rented successfully!";
            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Return(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Index", "Login");

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);
            if (user == null)
                return RedirectToAction("Index", "Login");

            var rental = _context.Rentals.FirstOrDefault(r =>
                r.MovieId == id && r.UserId == user.Id && r.ReturnedOn == null);

            if (rental == null)
            {
                TempData["Error"] = "No active rental found for this movie.";
                return RedirectToAction("Details", new { id });
            }

            rental.ReturnedOn = DateTime.Now;

            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                movie.Quantity += 1;
                movie.IsAvailable = true;
            }

            _context.SaveChanges();

            TempData["Success"] = "Movie returned successfully.";
            return RedirectToAction("Details", new { id });
        }
    }
}
