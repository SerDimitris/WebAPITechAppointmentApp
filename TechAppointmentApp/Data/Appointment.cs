using TechAppointmentApp.Core.Enums;

namespace TechAppointmentApp.Data
{
    public class Appointment : BaseEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TechnicianId { get; set; }
        public int AreaId { get; set; }
        public int ServiceId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Technician Technician { get; set; } = null!;
        public virtual Area? Area { get; set; }
        public virtual Service? Service { get; set; }


    }
}