namespace TechAppointmentApp.Data
{
    public class Area
    {
        public int Id { get; set; }
        public string AreaName { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Technician> Technicians { get; set; } = new HashSet<Technician>();
    }
}
