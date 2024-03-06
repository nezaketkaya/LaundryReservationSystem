using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LaundryReservationSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserPhone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTimeStart { get; set; }
        public string MachineType { get; set; }
        public int MachineNumber { get; set; }


        

    }
}
