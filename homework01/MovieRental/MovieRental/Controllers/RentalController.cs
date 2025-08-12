using Microsoft.AspNetCore.Mvc;
using MovieRental.DataAccess;
using MovieRental.Dtos.ViewModels;

namespace MovieRental.Controllers
{
    public class RentalController : Controller
    {
        private readonly MovieRentalContext _context;

        public RentalController(MovieRentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ReturnList()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue) return RedirectToAction("Index", "Login");

            var items = (from r in _context.Rentals
                         join m in _context.Movies on r.MovieId equals m.Id
                         where r.UserId == userId.Value
                         orderby (r.ReturnedOn == null) descending, r.RentedOn descending
                         select new
                         {
                             RentalId = r.Id,
                             MovieId = m.Id,
                             Title = m.Title,
                             Genre = m.Genre,
                             RentedOn = r.RentedOn,
                             ReturnedOn = r.ReturnedOn,
                             IsReturned = r.ReturnedOn != null
                         }).ToList();

            ViewBag.JustReturnedId = TempData["JustReturnedId"];
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Return(int rentalId, int movieId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue) return RedirectToAction("Index", "Login");

            var rental = _context.Rentals.FirstOrDefault(r =>
                r.Id == rentalId && r.UserId == userId.Value &&
                r.MovieId == movieId && r.ReturnedOn == null);

            if (rental == null)
            {
                TempData["Error"] = "Active rental not found.";
                return RedirectToAction("ReturnList");
            }

            rental.ReturnedOn = DateTime.Now;

            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie != null)
            {
                movie.Quantity += 1;
                movie.IsAvailable = true;
            }

            _context.SaveChanges();

            TempData["Success"] = "Movie returned successfully.";
            TempData["JustReturnedId"] = rental.Id;
            return RedirectToAction("ReturnList");
        }
    }
}
