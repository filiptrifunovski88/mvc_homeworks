using Microsoft.AspNetCore.Mvc;
using MovieRental.DataAccess;
using MovieRental.Dtos.ViewModels;

namespace MovieRental.Controllers
{
    public class LoginController : Controller
    {
        private readonly MovieRentalContext _context;

        public LoginController(MovieRentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users.FirstOrDefault(u => u.CardNumber == model.CardNumber);
            if (user == null)
            {
                ModelState.AddModelError("CardNumber", "Invalid Card Number.");
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Index", "Home");
        }
    }
}
