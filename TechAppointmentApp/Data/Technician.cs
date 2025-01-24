namespace TechAppointmentApp.Data
{
    public class Technician : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AreaId { get; set; }
        public virtual Area? Area { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
