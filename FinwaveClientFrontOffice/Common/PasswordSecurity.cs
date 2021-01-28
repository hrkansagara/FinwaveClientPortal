using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FinwaveClientFrontOffice.Common
{
    public class PasswordSecurity
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("BhavCool");

        public static string EncryptPassword(string Password)
        {
            if (String.IsNullOrEmpty(Password))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }
            Password = Password.ToUpper();
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(Password);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public static string DecryptPassword(string Password)
        {
            if (String.IsNullOrEmpty(Password))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }
            Password = Password.Replace(" ", "+");
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(Password));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd().ToUpper();
        }
    }
}