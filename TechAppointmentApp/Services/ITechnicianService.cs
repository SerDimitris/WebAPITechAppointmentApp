using TechAppointmentApp.Data;

namespace TechAppointmentApp.Services
{
    public interface ITechnicianService
    {
        Task<IEnumerable<User>> GetAllTechniciansAsync();
        //Task<List<Service>> GetTechniciansServicesAsync(int id);
        Task<Technician?> GetTechnicianByIdAsync(int id);
        Task<bool> DeleteTechnicianAsync(int id);
        Task<int> GetTechnicianCountAsync();
    }
}
