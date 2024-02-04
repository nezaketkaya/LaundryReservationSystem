using System.ComponentModel.DataAnnotations;

namespace LaundryReservationSystem.Models
{
    public class UserBooking
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookingDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime BookingTimeStart { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime BookingTimeFinish { get; set; }
        public string MachineType { get; set; }

        public int MachineNumber { get; set; }
    }
}
