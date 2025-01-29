using Microsoft.EntityFrameworkCore;
using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public class ServiceRepository : IBaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetServiceCustomersAsync(int id)
        {
            return await context.Services
                .Where(s => s.Id == id)
                .SelectMany(s => s.Customers)
                .ToListAsync();
        }

        public async Task<List<Technician>> GetServiceTechniciansAsync(int id)
        {
            return await context.Services
                .Where (s => s.Id == id)
                .SelectMany(s => s.Technicians)
                .ToListAsync();
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await context.Services
                .Include(s => s.Customers)
                .Include(s => s.Technicians)
                .ToListAsync ();
        }
    }
}
