using TechAppointmentApp.Core.Enums;

namespace TechAppointmentApp.DTO
{
    public class CustomerAppointmentReadOnlyDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? Firstname { get; set; }
        public string Lastname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }
}
