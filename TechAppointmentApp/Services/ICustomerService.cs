using TechAppointmentApp.Data;
using TechAppointmentApp.DTO;

namespace TechAppointmentApp.Services
{
    public interface ICustomerService
    {
        Task SignUpUserAsync(CustomerSignupDTO request);
    }
}
