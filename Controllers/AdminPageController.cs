using LaundryReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaundryReservationSystem.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly AppDbContext _dbContext;
        public AdminPageController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser(User newUser)
        {

            return View();
        }

    }
}
