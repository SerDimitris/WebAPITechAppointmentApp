using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public interface IServiceRepository
    {
        Task<Service?> GetServiceByNameAsync(string name);
    }
}
