using System.ComponentModel.DataAnnotations;
using TechAppointmentApp.Core.Enums;

namespace TechAppointmentApp.DTO
{
    public class TechnicianSignupDTO
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 50 characters.")]
        public string? Username { get; set; }

        [StringLength(100, ErrorMessage = "Email must not exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email adress.")]
        public string? Email { get; set; }

        [RegularExpression(@"(?=.*?[A-Z])(?=.*?[a-z])(?=.*\d)(?=.*\W)^.{8,}$",
            ErrorMessage = "Password must be at least 8 characters long, include an uppercase letter, a lowercase letter, a number, and a symbolic character.")]
        public string? Password { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstname must be between 2 and 50 characters.")]
        public string? Firstname { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname must be between 2 and 50 characters.")]
        public string? Lastname { get; set; }

        [StringLength(15, MinimumLength = 10, ErrorMessage = "Username must be between 10 and 15 characters.")]
        public string? PhoneNumber { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Area must be between 5 and 100 characters.")]
        public string? Area { get; set; }

        [EnumDataType(typeof(UserService), ErrorMessage = "Invalid service.")]
        public UserService? Service { get; set; }

        [EnumDataType(typeof(UserRole), ErrorMessage = "Invalid user role.")]
        public UserRole? UserRole { get; set; }
    }
}
