using System.Security.Cryptography;
using System.Text;

namespace PocBancoAPI.Shared.PasswordUtility
{
    public static class PasswordHashUtility
    {
        public static void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmacsha = new HMACSHA512())
            {
                passwordSalt = hmacsha.Key;
                passwordHash = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool CheckHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmacsha = new HMACSHA512(passwordSalt))
            {
                var hashCalculado = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < hashCalculado.Length; i++)
                {
                    if (hashCalculado[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}