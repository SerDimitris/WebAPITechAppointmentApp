
using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechAppointmentAppDbContext _context;

        public UnitOfWork(TechAppointmentAppDbContext context)
        {
            _context = context;
        }
        public UserRepository UserRepository => new(_context);
        public CustomerRepository CustomerRepository => new(_context);

        public TechnicianRepository TechnicianRepository => new(_context);

        public AreaRepository AreaRepository => new (_context);

        public ServiceRepository ServiceRepository => new(_context);
        public AppointmentRepository AppointmentRepository => new (_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
