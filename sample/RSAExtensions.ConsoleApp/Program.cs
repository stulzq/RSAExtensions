using System;
using System.Security.Cryptography;
using System.Text;

namespace RSAExtensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = RSA.Create(512);
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Pkcs1));
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Pkcs1, true));
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Pkcs8));
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Pkcs8,true));

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Xml));
            Console.WriteLine("-----------------------------------------");

            var data = "11111111111111111111111111111111111111111111111111111111111111111111";

            var encrypt = rsa.EncryptBigData(data, RSAEncryptionPadding.OaepSHA1);
            Console.WriteLine(encrypt);
            var decrypt = rsa.DecryptBigData(encrypt, RSAEncryptionPadding.OaepSHA1);
            Console.WriteLine(decrypt);
        }
    }
}
