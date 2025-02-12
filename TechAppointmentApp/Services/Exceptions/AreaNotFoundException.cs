namespace TechAppointmentApp.Services.Exceptions
{
    public class AreaNotFoundException : AppException
    {
        private static readonly string DEFAULT_CODE = "Not_Found";

        public AreaNotFoundException(string code, string message) : base(code + DEFAULT_CODE, message)
        {
        }
    }
}
