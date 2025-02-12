
using AutoMapper;
using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechAppointmentAppDbContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(TechAppointmentAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserRepository UserRepository => new(_context, _mapper);

        public AppointmentRepository AppointmentRepository => new (_context);
        public CustomerRepository CustomerRepository => new (_context);
        public TechnicianRepository TechnicianRepository => new (_context);
        public AreaRepository AreaRepository => new (_context);
        public ServiceRepository ServiceRepository => new (_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
