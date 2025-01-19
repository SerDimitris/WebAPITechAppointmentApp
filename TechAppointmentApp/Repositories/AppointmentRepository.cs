using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }
    }
}
