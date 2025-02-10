using TechAppointmentApp.Core.Enums;

namespace TechAppointmentApp.DTO
{
    public class CustomerFiltersDTO
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public UserRole? UserRole { get; set; }
    }
}
