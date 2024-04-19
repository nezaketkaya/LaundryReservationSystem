using LaundryReservationSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LaundryReservationSystem.Controllers
{
    public class BookingController : Controller
    {

        private readonly AppDbContext _dbContext;
        public BookingController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public IActionResult GetAvailableMachines(DateTime date, TimeSpan startTime, string machineType)
        {

            var reservedMachines = _dbContext.Bookings
                .Where(b => b.BookingDate == date &&
                            b.BookingTimeStart == startTime &&
                        b.MachineType == machineType)
                .Select(b => b.MachineNumber)
                .ToList();

            var allMachines = _dbContext.Machines
                .Where(m => m.MachineType == machineType && m.isFaulty == false)
                .Select(m => m.MachineNumber)
                .ToList();

            var availableMachines = allMachines.Except(reservedMachines).ToList();

            return Json(availableMachines);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var machineTypes = _dbContext.Machines.Select(m => m.MachineType).Distinct().ToList();

            ViewBag.MachineType = machineTypes;

          
            return View();
        }

        [HttpPost]
        public ActionResult Create(Booking newBooking)
        {           
           
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Bookings.Add(newBooking);
                    
                    _dbContext.SaveChanges();

                    TempData["SuccessMessage"] = "Reservation has been successfully saved.";

                    return RedirectToAction("Create");
                }
                else
                {
                    TempData["ErrorMessage"] = "Reservation could not be saved. Please check your inputs.";

                    return View(newBooking);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        private ActionResult RedirectToAction(Func<ActionResult> ındex)
        {
            throw new NotImplementedException();
        }
      
    }
}

