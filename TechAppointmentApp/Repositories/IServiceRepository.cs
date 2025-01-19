using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllAsync();
        Task<List<Customer>> GetServiceCustomersAsync(int id);
        Task<List<Technician>> GetServiceTechniciansAsync(int id);
    }
}
