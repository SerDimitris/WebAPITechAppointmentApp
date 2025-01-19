using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string username, string password);
        Task<User?> UpdateUserAsync(int id, User user);
        Task<User?> GetByUserName(string username);
        Task<List<User>> GetAllUsersFilteredPaginatedAsync(int pageNumber, int pageSize,
            List<Func<User, bool>> predicates);

    }
}
