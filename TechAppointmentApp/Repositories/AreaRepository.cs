using Microsoft.EntityFrameworkCore;
using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetAreaCustomersAsync(int id)
        {
            return await context.Areas
                .Where(a => a.Id == id)
                .SelectMany(a => a.Customers)
                .ToListAsync();
        }

        public async Task<List<Technician>> GetAreaTechniciansAsync(int id)
        {
            return await context.Areas
                .Where (a => a.Id == id)
                .SelectMany(a => a.Technicians)
                .ToListAsync();
        }
    }
}
