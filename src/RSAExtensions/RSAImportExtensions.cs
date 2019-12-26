using System;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace RSAExtensions
{
    public static class RSAImportExtensions
    {
        /// <summary>
        /// Export RSA private key
        /// </summary>
        /// <param name="rsa"></param>
        /// <param name="type"></param>
        /// <param name="privateKey"></param>
        /// <param name="isPem">Only valid if the private key type is PKCS#1 and PKCS#8.</param>
        /// <returns></returns>
        public static void ImportPrivateKey(this RSA rsa, RSAKeyType type,string privateKey, bool isPem = false)
        {
            if (isPem)
            {
                privateKey = PemFormatUtil.RemoveFormat(privateKey);
            }

            switch (type)
            {
                case RSAKeyType.Pkcs1:
                    rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey),out _);
                    break;
                case RSAKeyType.Pkcs8:
                    rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(privateKey), out _);
                    break;
                case RSAKeyType.Xml:
                    rsa.ImportXmlPrivateKey(privateKey);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        /// Export RSA public key
        /// </summary>
        /// <param name="rsa"></param>
        /// <param name="type"></param>
        /// <param name="publicKey"></param>
        /// <param name="isPem">Only valid if the private key type is PKCS#1 and PKCS#8.</param>
        /// <returns></returns>
        public static void ImportPublicKey(this RSA rsa, RSAKeyType type, string publicKey, bool isPem = false)
        {
            if (isPem)
            {
                publicKey = PemFormatUtil.RemoveFormat(publicKey);
            }

            switch (type)
            {
                case RSAKeyType.Pkcs1:
                    rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);
                    break;
                case RSAKeyType.Pkcs8:
                    rsa.ImportPkcs8PublicKey(Convert.FromBase64String(publicKey));
                    break;
                case RSAKeyType.Xml:
                    rsa.ImportXmlPublicKey(publicKey);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static void ImportPkcs8PublicKey(this RSA rsa,byte[] publicKey)
        {
            RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(publicKey);
            var pub = new RSAParameters
            {
                Modulus = publicKeyParam.Modulus.ToByteArrayUnsigned(),
                Exponent = publicKeyParam.Exponent.ToByteArrayUnsigned()
            };
            rsa.ImportParameters(pub);
        }
    }

}