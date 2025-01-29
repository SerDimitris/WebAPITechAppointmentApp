using Microsoft.EntityFrameworkCore;
using TechAppointmentApp.Data;
using TechAppointmentApp.Security;

namespace TechAppointmentApp.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllUsersFilteredPaginatedAsync(int pageNumber, int pageSize,
            List<Func<User, bool>> predicates)
        {
            int skip = (pageNumber - 1) * pageSize;
            IQueryable<User> query = context.Users.Skip(skip).Take(pageSize);

            if (predicates != null && predicates.Any())
            {
                query = query.Where(u => predicates.All(predicate => predicate(u)));
            }
            return await query.ToListAsync();
        }

        public async Task<User?> GetByPhoneNumberAsync(string phoneNumber) => await context.Users
            .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

        public async Task<User?> GetByUserNameAsync(string username) => await context.Users
            .FirstOrDefaultAsync(u => u.Username == username);

        public async Task<User?> GetUserAsync(string username, string password)
        {
            return await context.Users.FirstOrDefaultAsync(u =>
            (u.Username == username || u.Username == username)
            && EncryptionUtil.IsValidPassword(password, u.Password));
        }

        public async Task<User?> GetUserByIdAsync(int id) => await context.Users
            .FirstOrDefaultAsync (u => u.Id == id);

        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existingUser is null) return null;
            if(existingUser.Id != id) return null;

            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            return existingUser;
        }
    }
}
