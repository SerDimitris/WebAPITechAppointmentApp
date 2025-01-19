using Microsoft.EntityFrameworkCore;
using TechAppointmentApp.Core.Enums;
using TechAppointmentApp.Data;
using TechAppointmentApp.Models;

namespace TechAppointmentApp.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }

        public async Task<Customer?> GetByPhoneNmumberAsync(string phoneNumber)
        {
            return await context.Customers
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.User.PhoneNumber == phoneNumber);
        }

        public async Task<List<Appointment>> GetCustomerAppoitmentsAsync(int id)
        {
            List<Appointment> appointments;

            appointments = await context.Customers     
                .Where(c => c.Id == id)
                .SelectMany(c => c.Appointments)
                .ToListAsync();

            return appointments;
        }

        public async Task<List<User>> GetAllUsersCustomersAsync()
        {
            var usersWithCustomerRole = await context.Users
                .Where(u => u.UserRole == UserRole.Customer)
                .Include(u => u.Customer)
                .ToListAsync();

            return usersWithCustomerRole;
        }

        public async Task<List<User>> GetAllUsersCustomersPaginatedAsync(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;
            var usersWithCustomerRole = await context.Users
                .Where(u => u.UserRole == UserRole.Customer)
                .Include(u => u.Customer)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return usersWithCustomerRole;
        }

        public async Task<PaginatedResult<User>> GetPaginatedUsersCustomersAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await context.Users
                .Where(u => u.UserRole == UserRole.Customer)
                .CountAsync();

            int skip = (pageNumber - 1) * pageSize;
            var usersWithCustomerRole = await context.Users
                .Where(u => u.UserRole == UserRole.Customer)
                .Include(u => u.Customer)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<User>
            {
                Data = usersWithCustomerRole,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }
        public async Task<PaginatedResult<User>> GetPaginatedUsersCustomersFilteredAsync(int pageNumber, int pageSize,
            List<Func<User, bool>> predicates)
        {
            var totalRecords = await context.Users
                .Where(u => u.UserRole == UserRole.Customer)
                .CountAsync();

            int skip = (pageNumber - 1) * pageSize;

            IQueryable <User> query = context.Users
                .Where(u => u.UserRole == UserRole.Customer)
                .Skip(skip)
                .Take(pageSize);
            
            if (predicates != null && predicates.Any())
            {
                query = query.Where(u => predicates.All(predicate => predicate(u)));
            }

            var usersCustomers = await query.ToListAsync();

            return new PaginatedResult<User>
            {
                Data = usersCustomers,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<Appointment>> GetCustomerAppoitmentByStatusAsync(int id, string status)
        {
            return await context.Customers
                .Where(c => c.Id == id)
                .SelectMany(c => c.Appointments)
                .Where(s => s.Status == status)
                .ToListAsync();
        }

    }
}