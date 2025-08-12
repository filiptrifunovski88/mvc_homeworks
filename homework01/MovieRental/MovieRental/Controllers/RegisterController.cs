using Microsoft.AspNetCore.Mvc;
using MovieRental.Domain.Models;
using MovieRental.DataAccess;
using MovieRental.Dtos.ViewModels;

namespace MovieRental.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MovieRentalContext _context;

        public RegisterController(MovieRentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_context.Users.Any(u => u.CardNumber == model.CardNumber))
            {
                ModelState.AddModelError("CardNumber", "Card Number already exists.");
                return View(model);
            }

            var user = new User
            {
                FullName = model.FullName,
                Age = model.Age,
                CardNumber = model.CardNumber,
                CreatedOn = DateTime.Now,
                IsSubscriptionExpired = false,
                SubscriptionType = 0
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}
