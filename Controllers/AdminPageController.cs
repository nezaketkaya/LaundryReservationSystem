using LaundryReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult CheckPhoneNumber(string phoneNumber)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.UserPhone == phoneNumber);
            return Json(new { exists = existingUser != null });
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            var users = _dbContext.Users.ToList();
            ViewBag.UsersInfo = users;


            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User newUser)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _dbContext.Users.Add(newUser);
                    _dbContext.SaveChanges();

                    return RedirectToAction("AddUser");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid inputs, please check your information.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred, please try again.";
            }

            return View(newUser);
        }

        [HttpPost]
        public IActionResult DeleteUser(User userD)
        {
            var user = _dbContext.Users.Find(userD.Id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();

                return RedirectToAction("AddUser");
            }

            return RedirectToAction("AddUser");
        }


    }
}
