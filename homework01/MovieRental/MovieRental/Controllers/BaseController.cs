using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieRental.DataAccess;

public class BaseController : Controller
{
    protected readonly MovieRentalContext _context;
    public BaseController(MovieRentalContext context)
    {
        _context = context;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId.HasValue)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);
            ViewBag.LoggedInUser = user;
        }
        base.OnActionExecuting(context);
    }
}
