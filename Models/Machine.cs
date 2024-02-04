namespace LaundryReservationSystem.Models
{
    public class Machine
    {
        public int Id { get; set; }

        public string MachineType { get; set; }

        public int MachineNumber { get; set; }

        public bool IsRunning { get; set; }

        public bool isFaulty { get; set; }

    }
}
