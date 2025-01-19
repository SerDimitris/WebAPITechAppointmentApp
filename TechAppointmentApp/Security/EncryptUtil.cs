
namespace TechAppointmentApp.Security
{
    public static class EncryptionUtil
    {
        public static string Encrypt(string plaintText)
        {
            var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(plaintText);
            return encryptedPassword;
        }

        public static bool IsValidPassword(string plaintText, string cipherText)
        {
            return BCrypt.Net.BCrypt.Verify(plaintText, cipherText);
        }

        internal static bool IsValidPassword(string password1, object password2)
        {
            throw new NotImplementedException();
        }
    }
}
