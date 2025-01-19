using System.ComponentModel.DataAnnotations;

namespace TechAppointmentApp.DTO
{
    public class UserLoginDTO
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 50 characters.")]
        public string? Username { get; set; }

        [RegularExpression(@"(?=.*?[A-Z])(?=.*?[a-z])(?=.*\d)(?=.*\W)^.{8,}$",
            ErrorMessage = "Password must be at least 8 characters long, include an uppercase letter, a lowercase letter, a number, and a symbolic character.")]
        public string? Password { get; set; }
        public bool? KeepLoggedIn { get; set; }
    }
}
