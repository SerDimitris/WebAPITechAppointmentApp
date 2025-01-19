using System.Data;
using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public interface IAreaRepository
    {
        Task<List<Customer>> GetAreaCustomersAsync(int id);
        Task<List<Technician>> GetAreaTechniciansAsync(int id);
    }
}
