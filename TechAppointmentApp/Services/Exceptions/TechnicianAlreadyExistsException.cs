namespace TechAppointmentApp.Services.Exceptions
{
    public class TechnicianAlreadyExistsException : Exception
    {
        public TechnicianAlreadyExistsException(string s) : base(s)
        {
        }
    }
}
