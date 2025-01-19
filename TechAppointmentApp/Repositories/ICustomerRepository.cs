using TechAppointmentApp.Data;
using TechAppointmentApp.Models;

namespace TechAppointmentApp.Repositories
{
    public interface ICustomerRepository 
    {
        Task<List<Appointment>> GetCustomerAppoitmentsAsync(int id);
        Task<List<Appointment>> GetCustomerAppoitmentByStatusAsync(int id, string status);
        Task<Customer?> GetCustomerByPhoneNmumberAsync(string phoneNumber);
        Task<List<User>> GetAllUsersCustomersAsync();
        Task<List<User>> GetAllUsersCustomersPaginatedAsync(int pageNumber, int pageSize);
        Task<PaginatedResult<User>> GetPaginatedUsersCustomersAsync(int pageNumber, int pageSize);
        Task<PaginatedResult<User>> GetPaginatedUsersCustomersFilteredAsync(int pageNumber, int pageSize, List<Func<User, bool>> predicates);
    }
}
