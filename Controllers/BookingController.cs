using LaundryReservationSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaundryReservationSystem.Controllers
{
    public class BookingController : Controller
    {

        private readonly AppDbContext _dbContext;



        private void CheckMachineStatus(Machine machine)
        {
            
            if (machine.IsRunning)
            {
                
            }

            if (machine.isFaulty)
            {
                // Makine arızalıysa yapılacak işlemler
                // Örneğin: Teknik servisi bilgilendirme, kayıt tutma vb.
            }
        }

        public BookingController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking newBooking)
        {           
            ViewBag.MachineTypes = new SelectList(_dbContext.Machines.Select(m => m.MachineType).Distinct().ToList());
            ViewBag.MachineNumbers = new SelectList(_dbContext.Machines.Select(m => m.MachineNumber).Distinct().ToList());
           
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




        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
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

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
