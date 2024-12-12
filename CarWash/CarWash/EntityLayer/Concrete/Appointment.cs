using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    /// <summary>
    /// Randevu
    /// </summary>
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public bool AppointmentStatus { get; set; }
        public DateTime AppointmentEntryTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }


    }
}
