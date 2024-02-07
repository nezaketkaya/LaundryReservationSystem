using LaundryReservationSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

          private IEnumerable<Machine> GetAvailableMachines(DateTime startTime, DateTime finishTime, string machineType)
          {
              var allMachines = _dbContext.Machines.ToList();

              var reservedMachines = _dbContext.Bookings
                  .Where(b =>
                      (startTime >= b.BookingTimeStart && startTime < b.BookingTimeFinish) ||
                      (finishTime > b.BookingTimeStart && finishTime <= b.BookingTimeFinish) ||
                      (startTime <= b.BookingTimeStart && finishTime >= b.BookingTimeFinish))
                  .Select(b => b.Id)
                  .Distinct()
                  .ToList();

              var availableMachines = allMachines
                  .Where(m => !reservedMachines.Contains(m.Id) && m.MachineType == machineType);

              return availableMachines;
          } 


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TimeOptions = new SelectList(new[]
        {
             new SelectListItem { Value = "08:00", Text = "8:00" },
             new SelectListItem { Value = "09:00", Text = "9:00" },
             new SelectListItem { Value = "10:00", Text = "10:00" },
             new SelectListItem { Value = "11:00", Text = "11:00" },
             new SelectListItem { Value = "12:00", Text = "12:00" },
             new SelectListItem { Value = "13:00", Text = "13:00" },
             new SelectListItem { Value = "14:00", Text = "14:00" },
             new SelectListItem { Value = "15:00", Text = "15:00" },
             new SelectListItem { Value = "16:00", Text = "16:00" },
             new SelectListItem { Value = "17:00", Text = "17:00" },
             new SelectListItem { Value = "18:00", Text = "18:00" },
             new SelectListItem { Value = "19:00", Text = "19:00" },
             new SelectListItem { Value = "20:00", Text = "20:00" },
             new SelectListItem { Value = "21:00", Text = "21:00" },
             new SelectListItem { Value = "22:00", Text = "22:00" },
             new SelectListItem { Value = "23:00", Text = "23:00" },

           }, "Value", "Text");

            var machineTypes = _dbContext.Machines.Select(m => m.MachineType).Distinct().ToList();
            SelectList machineTypeList = new SelectList(machineTypes, "MachineType");
            ViewBag.MachineType = machineTypeList;
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
                    newBooking.BookingTimeFinish = newBooking.BookingTimeStart.AddHours(1);
                    _dbContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
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

