using LaundryReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaundryReservationSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var bookings = _dbContext.Bookings.ToList();
            ViewBag.BookingsInfo = bookings;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
