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
            switch (type)
            {
                case RSAKeyType.Pkcs1:
                    return GetPkcs1PublicKeyFormat(publicKey);
                case RSAKeyType.Pkcs8:
                    return GetPkcs8PublicKeyFormat(publicKey);
                default:
                    throw new Exception($"Public key type {type.ToString()} does not support pem formatting.");
            }
        }

        public static string GetPrivateKeyFormat(RSAKeyType type, string privateKey)
        {
            switch (type)
            {
                case RSAKeyType.Pkcs1:
                    return GetPkcs1PrivateKeyFormat(privateKey);
                case RSAKeyType.Pkcs8:
                    return GetPkcs8PrivateKeyFormat(privateKey);
                default:
                    throw new Exception($"Private key type {type.ToString()} does not support pem formatting.");
            }
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
                .Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "").Replace(Environment.NewLine, "")
                .Replace("-----BEGIN RSA PUBLIC KEY-----", "").Replace("-----END RSA PUBLIC KEY-----", "").Replace(Environment.NewLine, "")
                .Replace("-----BEGIN PRIVATE KEY-----", "").Replace("-----END PRIVATE KEY-----", "").Replace(Environment.NewLine, "")
                .Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace(Environment.NewLine, "");
        }

        private static void AppendBody(StringBuilder sb, string key)
        {
            var count = Convert.ToInt32(Math.Ceiling(key.Length * 1.0 / 64));
            for (int i = 0; i < count; i++)
            {
                var start = i * 64;
                var end = start + 63;
                if (end > key.Length - 1)
                {
                    end = key.Length - 1;
                }
                sb.AppendLine(key[start..end]);
            }
        }
    }
}