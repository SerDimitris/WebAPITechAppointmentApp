using TechAppointmentApp.Data;
using TechAppointmentApp.DTO;

namespace TechAppointmentApp.Services
{
    public interface ICustomerService
    {
        Task<User?> SignUpCustomerAsync(CustomerSignupDTO request);
        Task<User?> UpdateCustomerAsync(int id, CustomerDTO customerDTO);
        Task<User?> UpdateCustomerPatchAsync(int id, CustomerPatchDTO request);
        Task<User?> GetCustomerByUsernameAsync(string username);
        Task<List<User>> GetAllCustomersFiltered(int pageNumber,  int pageSize, CustomerFiltersDTO customerFiltersDTO);
        
    }
}
