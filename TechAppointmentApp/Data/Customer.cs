namespace TechAppointmentApp.Data
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public int UserId { get; set; }
        public int? AreadId { get; set; }
        public int? ServiceId { get; set; }
        public virtual Area? Area { get; set; }
        public virtual Service? Service { get; set; }
        public virtual User User { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
