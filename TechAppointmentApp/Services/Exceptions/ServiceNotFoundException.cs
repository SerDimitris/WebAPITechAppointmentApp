
namespace TechAppointmentApp.Services.Exceptions
{
    public class ServiceNotFoundException : AppException
    {
        private static readonly string DEFAULT_CODE = "Not_Found";
        public ServiceNotFoundException(string code, string message) : base(code + DEFAULT_CODE, message)
        {
        }
    }
}
