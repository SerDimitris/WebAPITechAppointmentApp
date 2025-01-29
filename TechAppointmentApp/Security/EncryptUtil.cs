
namespace TechAppointmentApp.Security
{
    public static class EncryptionUtil
    {
        public static string Encrypt(string plainText)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainText);
             
        }

        public static bool IsValidPassword(string plainText, string cipherText)
        {
            return BCrypt.Net.BCrypt.Verify(plainText, cipherText);
        }
    }
}
