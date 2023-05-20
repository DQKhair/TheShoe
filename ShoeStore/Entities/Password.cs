using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace ShoeStore.Entities
{
    public class PasswordOption
    {
        public static string Encrypt(string origin)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(origin, salt);


            return hash;
        }

        public static bool Validation(string password,string hashPassword)
        {
            bool result = BCrypt.Net.BCrypt.Verify(password, hashPassword);
            return result;
        }
    }
}