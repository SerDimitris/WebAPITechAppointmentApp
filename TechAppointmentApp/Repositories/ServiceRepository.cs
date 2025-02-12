using Microsoft.EntityFrameworkCore;
using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }

        public async Task<Service?> GetServiceByNameAsync(string name)
        {
            return await _context.Services
                .FirstOrDefaultAsync(s => s.UserService.ToString() == name);
        }
    }
}