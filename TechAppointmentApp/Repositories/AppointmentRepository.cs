using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public class AppointmentRepository : IBaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }
    }
}
