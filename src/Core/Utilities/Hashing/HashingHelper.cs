﻿using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Hashing
{
    public static class HashingHelper
    {       
            public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                using HMACSHA512 hmac = new HMACSHA512();

                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }

            public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
            {
                using HMACSHA512 hmac = new HMACSHA512(passwordSalt);

                hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);

            }
    }
}
