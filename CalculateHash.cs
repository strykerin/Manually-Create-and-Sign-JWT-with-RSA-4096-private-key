﻿using System.Security.Cryptography;
using System.Text;

namespace ManuallyCreateJWT
{
    public class CalculateHash
    {
        public static string SHA256HashFunction(string plainText)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute Hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // Convert byte array to string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
