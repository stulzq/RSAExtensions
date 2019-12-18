using System;
using System.Text;

namespace RSAExtensions
{
    /// <summary>
    /// doc https://tls.mbed.org/kb/cryptography/asn1-key-structures-in-der-and-pem
    /// </summary>
    internal class PemFormatUtil
    {
        public static string GetPublicKeyFormat(RSAKeyType type, string publicKey)
        {
            return type switch
            {
                RSAKeyType.Pkcs1 => GetPkcs1PublicKeyFormat(publicKey),
                RSAKeyType.Pkcs8 => GetPkcs8PublicKeyFormat(publicKey),
                _ => throw new Exception($"Public key type {type.ToString()} does not support pem formatting.")
            };
        }

        public static string GetPrivateKeyFormat(RSAKeyType type, string privateKey)
        {
            return type switch
            {
                RSAKeyType.Pkcs1 => GetPkcs1PrivateKeyFormat(privateKey),
                RSAKeyType.Pkcs8 => GetPkcs8PrivateKeyFormat(privateKey),
                _ => throw new Exception($"Private key type {type.ToString()} does not support pem formatting.")
            };
        }

        public static string GetPkcs1PrivateKeyFormat(string privateKey)
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----BEGIN RSA PRIVATE KEY-----");
            AppendBody(sb, privateKey);
            sb.AppendLine("-----END RSA PRIVATE KEY-----");

            return sb.ToString();
        }

        public static string GetPkcs8PrivateKeyFormat(string privateKey)
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----BEGIN PRIVATE KEY-----");
            AppendBody(sb, privateKey);
            sb.AppendLine("-----END PRIVATE KEY-----");

            return sb.ToString();
        }

        public static string GetPkcs1PublicKeyFormat(string publicKey)
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----BEGIN RSA PUBLIC KEY-----");
            AppendBody(sb, publicKey);
            sb.AppendLine("-----END RSA PUBLIC KEY-----");

            return sb.ToString();
        }

        public static string GetPkcs8PublicKeyFormat(string publicKey)
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----BEGIN PUBLIC KEY-----");
            AppendBody(sb, publicKey);
            sb.AppendLine("-----END PUBLIC KEY-----");

            return sb.ToString();
        }

        public static string RemoveFormat(string key)
        {
            return key
                .Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "")
                .Replace("-----BEGIN RSA PUBLIC KEY-----", "").Replace("-----END RSA PUBLIC KEY-----", "")
                .Replace("-----BEGIN PRIVATE KEY-----", "").Replace("-----END PRIVATE KEY-----", "")
                .Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "")
                .Replace(Environment.NewLine, "");
        }

        private static void AppendBody(StringBuilder sb, string key)
        {
            var count = Convert.ToInt32(Math.Ceiling(key.Length * 1.0 / 64));
            for (int i = 0; i < count; i++)
            {
                var start = i * 64;
                var end = start + 64;
                if (end >= key.Length)
                {
                    end = key.Length;
                }
                sb.AppendLine(key[start..end]);
            }
        }
    }
}