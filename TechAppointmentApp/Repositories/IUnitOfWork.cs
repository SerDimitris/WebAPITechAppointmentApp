namespace TechAppointmentApp.Repositories
{
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }
        CustomerRepository CustomerRepository { get; }
        TechnicianRepository TechnicianRepository { get; }
        AreaRepository AreaRepository { get; }
        ServiceRepository ServiceRepository { get; }
        AppointmentRepository AppointmentRepository { get; }

        Task<bool> SaveAsync();
    }
}
