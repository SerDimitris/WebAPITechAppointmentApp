namespace TechAppointmentApp.Repositories
{
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }
        AppointmentRepository AppointmentRepository { get; }

        Task<bool> SaveAsync();
    }
}
