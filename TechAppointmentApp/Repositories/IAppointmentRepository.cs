using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointmentsByCustomerIdPaginatedAsync(int id);
        Task<List<Appointment>> GetCustomerAppointmentsByStatusAsync(string status);
        Task<List<Appointment>> GetAppointmentsByTechnicianIdPaginatedAsync(int id);
        Task<List<Appointment>> GetTechnicianAppointmentsByStatusAsync(string status);
    }
}
