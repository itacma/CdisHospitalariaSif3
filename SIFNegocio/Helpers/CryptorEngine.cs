using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.Helpers
{
    public class CryptorEngine
    {
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            return SIFDatos.Helpers.CryptorEngine.Encrypt(toEncrypt, useHashing);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            return SIFDatos.Helpers.CryptorEngine.Decrypt(cipherString, useHashing);
        }

    }
}
