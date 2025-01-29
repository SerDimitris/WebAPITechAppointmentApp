using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointmentsByCustomerIdPaginatedAsync(int pageNumber, int pageSize, int id);
        Task<List<Appointment>> GetCustomerAppointmentsByStatusAsync(string status);
        Task<List<Appointment>> GetAppointmentsByTechnicianIdPaginatedAsync(int pageNumber, int pageSize, int id);
        Task<List<Appointment>> GetTechnicianAppointmentsByStatusAsync(string status);
    }
}
