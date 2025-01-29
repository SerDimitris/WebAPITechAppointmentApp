using System.Net;
using TechAppointmentApp.Core.Enums;

namespace TechAppointmentApp.Data
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string? Username { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? Firstname { get; set; } = null!;
        public string? Lastname { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public UserRole? UserRole { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Technician? Technician { get; set; }

        public override string? ToString()
        {
            return $"{Username}, {Email}, {Firstname}, {Lastname}, {PhoneNumber}, {UserRole}";
        }
    }
}