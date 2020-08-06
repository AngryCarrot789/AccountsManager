using AccountsManager.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using AccountsManager.Helpers;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager.Security
{
    public static class Encryption
    {
        private static byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private static int BlockSize = 128;

        public static string Encrypt(SecureString securePassword, string unencryptedText)
        {
            if (securePassword == null) 
                return "";

            byte[] bytes = Encoding.Unicode.GetBytes(unencryptedText);

            //Encrypt
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.BlockSize = BlockSize;
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(securePassword.GetUnsecure()));
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = 
                    new CryptoStream(
                        memoryStream, 
                        crypt.CreateEncryptor(), 
                        CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        public static string Decrypt(SecureString securePassword, string encryptedText)
        {
            if (securePassword == null)
                return "";

            //Decrypt
            byte[] bytes = Convert.FromBase64String(encryptedText);

            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(securePassword.GetUnsecure()));
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (CryptoStream cryptoStream = 
                    new CryptoStream(
                        memoryStream, 
                        crypt.CreateDecryptor(), 
                        CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[bytes.Length];
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);

                    return Encoding.Unicode.GetString(decryptedBytes);
                }
            }
        }
    }
}
