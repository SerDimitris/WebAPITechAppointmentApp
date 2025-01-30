using Microsoft.EntityFrameworkCore;
using TechAppointmentApp.Core.Enums;
using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }

        public async Task<List<Appointment>> GetAppointmentsByCustomerIdPaginatedAsync(int pageNumber, int pageSize, int id)
        {
            int skip = (pageNumber - 1) * pageSize;

            IQueryable<Appointment> query = _context.Appointments
                .Where(a => a.CustomerId == id)
                .OrderBy(a => a.AppointmentDate)
                .Skip(skip)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByTechnicianIdPaginatedAsync(int pageNumber,
            int pageSize, int id)
        {
            int skip = (pageNumber -1) * pageSize;

            IQueryable<Appointment> query = _context.Appointments
                .Where(a => a.TechnicianId == id)
                .OrderBy(a => a.AppointmentDate)
                .Skip(skip)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<List<Appointment>> GetCustomerAppointmentsByStatusAsync(string status)
        {
            if (!Enum.TryParse<AppointmentStatus>(status, true, out AppointmentStatus parsedStatus))
                throw new Exception("Invalid appointment status provided.");

            return await _context.Appointments
                .Where(a => a.Status == parsedStatus)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetTechnicianAppointmentsByStatusAsync(string status)
        {
            if (!Enum.TryParse<AppointmentStatus>(status, true, out AppointmentStatus parsedStatus))
                throw new Exception("Invalid appointment status provided.");

            return await _context.Appointments
                .Where(a => a.Status == parsedStatus)
                .ToListAsync();
        }
    }
}
