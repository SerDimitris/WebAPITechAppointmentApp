using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TechAppointmentApp.Data;
using TechAppointmentApp.Security;

namespace TechAppointmentApp.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(TechAppointmentAppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllUsersFilteredPaginatedAsync(int pageNumber, int pageSize,
            List<Func<User, bool>> predicates)
        {
            int skip = (pageNumber - 1) * pageSize;
            IQueryable<User> query = _context.Users.Skip(skip).Take(pageSize);

            if (predicates != null && predicates.Any())
            {
                query = query.Where(u => predicates.All(predicate => predicate(u)));
            }
            return await query.ToListAsync();
        }

        public async Task<User?> GetByPhoneNumberAsync(string phoneNumber) => await _context.Users
            .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

        public async Task<User?> GetByUsernameAsync(string username) => await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);

        public async Task<User?> GetUserAsync(string username, string password)
        {
            // The FirstOrDefaultAsync runs in database? If yes, the the password validation happents
            // when the user is fetched from db and then the Bcrypt runs as its a C# code.
            return await _context.Users.FirstOrDefaultAsync(u =>
            (u.Username == username || u.Email == username)
            && EncryptionUtil.IsValidPassword(password, u.Password!)); 

            // Alternative
            //var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username
            //|| x.Email == username);

            //if (user == null)
            //{
            //    return null;
            //}
            //if (!EncryptionUtil.IsValidPassword(password, user.Password!) {
            //    return null;
            //}
            //return user;
        }

        public async Task<User?> GetUserByIdAsync(int id) => await _context.Users
            .FirstOrDefaultAsync (u => u.Id == id);

        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            var existingUser = await _context.Users.
                Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            if(existingUser is null) return null;
            if(existingUser.Id != id) return null;

            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;

            return existingUser;
        }
    }
}
