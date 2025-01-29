using TechAppointmentApp.Core.Enums;

namespace TechAppointmentApp.DTO
{
    public class TechnicianAppointmentReadOnlyDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? Firstname { get; set; }
        public string Lastname { get; set; } = null!;
    }
}
