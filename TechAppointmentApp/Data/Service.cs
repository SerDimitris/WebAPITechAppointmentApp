using TechAppointmentApp.Core.Enums;

namespace TechAppointmentApp.Data
{
    public class Service
    {
        public int Id { get; set; }
        public UserService UserService { get; set; }
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Technician> Technicians { get; set; } = new HashSet<Technician>();

    }
}
