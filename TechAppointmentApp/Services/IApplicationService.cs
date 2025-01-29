namespace TechAppointmentApp.Services
{
    public interface IApplicationService
    {
        UserService UserService { get; }
        CustomerService CustomerService { get; }
        TechnicianService TechnicianService { get; }
    }
}
