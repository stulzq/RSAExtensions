using System;
using System.Security.Cryptography;

namespace RSAExtensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = RSA.Create();
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Pkcs1));
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Pkcs1, true));
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Pkcs8));
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Pkcs8,true));

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Xml));
        }
    }
}
