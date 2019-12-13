using System;
using System.Security.Cryptography;

namespace RSAExtensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = RSA.Create();

            Console.WriteLine(rsa.ExportXmlPublicKey());
            Console.WriteLine("-------------------------------");
            Console.WriteLine(rsa.ExportXmlPrivateKey());
        }
    }
}
