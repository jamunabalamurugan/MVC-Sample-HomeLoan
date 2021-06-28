using System.Text;
using System.Security.Cryptography;
namespace HomeLoan1
{
    public static class MD5Encrypt
    {
        public static string MD5Hash(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] res = md5.Hash;
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<res.Length;i++)
            {
                sb.Append(res[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}