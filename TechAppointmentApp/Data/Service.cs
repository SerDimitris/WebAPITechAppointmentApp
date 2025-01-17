namespace TechAppointmentApp.Data
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Technician> Technicians { get; set; } = new HashSet<Technician>();

    }
}
