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
        private void CheckMachineStatus(Machine machine)
        {

            if (machine.IsRunning)
            {

            }

            if (machine.isFaulty)
            {
                
            }
        }

        [HttpPost]
        public IActionResult GetAvailableMachines(DateTime date, DateTime startTime, string machineType)
        {
            var endTime = startTime.Add(TimeSpan.FromHours(1));

            var reservedMachines = _dbContext.Bookings
                .Where(b => b.BookingDate == date &&
                            ((b.BookingTimeStart >= startTime && b.BookingTimeStart < endTime) ||
                            (b.BookingTimeFinish > startTime && b.BookingTimeFinish <= endTime) ||
                            (b.BookingTimeStart <= startTime && b.BookingTimeFinish >= endTime)) &&
                        b.MachineType == machineType)
                .Select(b => b.MachineNumber)
                .ToList();

            var allMachines = _dbContext.Machines
                .Where(m => m.MachineType == machineType)
                .Select(m => m.MachineNumber)
                .ToList();

            var availableMachines = allMachines.Except(reservedMachines).ToList();

            return Json(availableMachines);
        }


        [HttpGet]
        public ActionResult Create(DateTime bookingTimeStart, string machineType)
        {
          

            var machineTypes = _dbContext.Machines.Select(m => m.MachineType).Distinct().ToList();

            SelectList machineTypeList = new SelectList(machineTypes, "MachineType");
            ViewBag.MachineType = machineTypeList;

          
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {           
            var newBooking = new Booking();
           
            try
            {
                if (ModelState.IsValid)
                {

                    _dbContext.Bookings.Add(newBooking);
                    newBooking.BookingTimeFinish = newBooking.BookingTimeStart.AddHours(1);
                    _dbContext.SaveChanges();

                    return View();
                }
                else
                {
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

     
        public ActionResult Delete(int id)
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

