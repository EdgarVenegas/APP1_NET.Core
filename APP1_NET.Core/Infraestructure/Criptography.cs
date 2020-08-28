using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.Infraestructure
{
    //Métodos para Validar PASSWORD

    public class Criptography
    {
        public static bool ValidacionPassword(string password, byte[] HashPassword, byte[] SaltPassword)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(SaltPassword)) 
            {
                var Computed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < Computed.Length; i++)
                {
                    if (Computed[i] != HashPassword[i]) return false;
                }
            }

            return true;

        }

        public static void CrearPasswordEncriptado(string Password, out byte[] HashPassword, out byte[] SaltPassword)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                SaltPassword = hmac.Key;
                HashPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }

    }
}
