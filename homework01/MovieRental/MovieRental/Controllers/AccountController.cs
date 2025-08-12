using Microsoft.AspNetCore.Mvc;
using MovieRental.DataAccess;

namespace MovieRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly MovieRentalContext _context;

        public AccountController(MovieRentalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Index", "Login");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);
            if (user == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Login");
            }

            ViewBag.LoggedInUser = user;

            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
