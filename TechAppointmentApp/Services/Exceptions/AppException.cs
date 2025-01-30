namespace TechAppointmentApp.Services.Exceptions
{
    public abstract class AppException : Exception
    {
        public string Code { get; set; }

        protected AppException(string code, string message)
        {
            Code = code;
        }
    }
}
