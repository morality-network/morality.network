using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RateIt.Utilities
{
    public class BankUtility
    {

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static byte[] ConvertStringToBytes(string salt)
        {
            return Encoding.ASCII.GetBytes(salt);
        }

        public static string Encrypt(string clearText, string encryptionKey, string salt)
        {
            string EncryptionKey = encryptionKey;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, ConvertStringToBytes(salt));
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText, string encKey, string salt)
        {
            string EncryptionKey = encKey;
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, ConvertStringToBytes(salt));
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static string GetNumberAsHex(double number)
        {
            string hexValue = number.ToString("X");
            return hexValue;
        }
        public static double GeHexAsNumber(string hex)
        {
            double doubleValue = double.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return doubleValue;
        }

        public static string PadToLength(string rawString, int length, char pad)
        {
            StringBuilder builder = new StringBuilder();
            int additionalValues = length - rawString.Length;
            if (additionalValues > 0)
            {
                for (int i = 0; i < additionalValues; i++)
                {
                    builder.Append(pad);
                }
            }
            builder.Append(rawString);
            return builder.ToString().Substring(0, length);
        }
    }
}
