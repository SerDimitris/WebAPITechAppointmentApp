using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string username, string password);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> UpdateUserAsync(int id, User user);
        Task<User?> GetByUserNameAsync(string username);
        Task<User?> GetByPhoneNumberAsync(string phoneNumber);
        Task<List<User>> GetAllUsersFilteredPaginatedAsync(int pageNumber, int pageSize,
            List<Func<User, bool>> predicates);

    }
}