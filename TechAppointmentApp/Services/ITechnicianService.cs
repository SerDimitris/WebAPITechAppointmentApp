using TechAppointmentApp.Data;

namespace TechAppointmentApp.Services
{
    public interface ITechnicianService
    {
        Task<User?> GetTechnicianByIdAsync(int id);
    }
}
