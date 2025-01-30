namespace TechAppointmentApp.Services.Exceptions
{
    public class CustomerAlreadyExistsException : Exception
    {
        public CustomerAlreadyExistsException(string s) : base(s)
        {
        }
    }
}
