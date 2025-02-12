namespace TechAppointmentApp.Repositories
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public AppointmentRepository AppointmentRepository { get; }
        public TechnicianRepository TechnicianRepository { get; }
        public CustomerRepository CustomerRepository { get; }
        public AreaRepository AreaRepository { get; }
        public ServiceRepository ServiceRepository { get; }

        Task<bool> SaveAsync();
    }
}
