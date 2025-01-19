namespace TechAppointmentApp.Data
{
    public class Technician : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AreaId { get; set; }
        public int? ServiceId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public virtual Area? Area { get; set; }
        public virtual Service? Service { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
