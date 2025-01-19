using TechAppointmentApp.Core.Filters;
using TechAppointmentApp.Data;
using TechAppointmentApp.DTO;

namespace TechAppointmentApp.Services
{
    public interface IUserService
    {
        Task<User?> VerifyAndGetUserAsync(UserLoginDTO credentials);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<List<User>> GetAllUsersFiltered(int pagaNumber, int pageSize,
            UserFiltersDTO userFiltersDTO);
    }
}
