using TechAppointmentApp.Data;
using TechAppointmentApp.DTO;

namespace TechAppointmentApp.Services
{
    public interface ICustomerService
    {
        Task SignUpUserAsync(CustomerSignupDTO request);
        Task<List<User>> GetAllUsersCustomersAsync();
        Task<List<User>> GetAllUsersCustomersAsync(int pageNumber, int pageSize);
        Task<int> GetCustomerCountAsync();
        Task<Customer?> GetCustomerByPhoneNumberAsync(string phoneNumber);
    }
}
