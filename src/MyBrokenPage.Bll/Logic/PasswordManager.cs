using System.Security.Cryptography;
using System.Text;

namespace MyBrokenPage.Bll.Logic
{
    public static class PasswordManager
    {
        public static string HashPassword(string password)
        {
            using (SHA1Managed sHA1 = new SHA1Managed())
            {
                var hash = sHA1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach(byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
