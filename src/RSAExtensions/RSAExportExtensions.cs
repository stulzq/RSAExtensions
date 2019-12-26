using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.OpenSsl;

namespace RSAExtensions
{
    /// <summary>
    /// RSA export key extensions.Support XML format import and export and PEM format.
    /// </summary>
    public static class RSAExportExtensions
    {
        /// <summary>
        /// Export RSA private key
        /// </summary>
        /// <param name="rsa"></param>
        /// <param name="type"></param>
        /// <param name="usePemFormat">Only valid if the private key type is PKCS#1 and PKCS#8.</param>
        /// <returns></returns>
        public static string ExportPrivateKey(this RSA rsa, RSAKeyType type, bool usePemFormat = false)
        {
            var key = type switch
            {
                RSAKeyType.Pkcs1 => Convert.ToBase64String(rsa.ExportRSAPrivateKey()),
                RSAKeyType.Pkcs8 => Convert.ToBase64String(rsa.ExportPkcs8PrivateKey()),
                RSAKeyType.Xml => rsa.ExportXmlPrivateKey(),
                _ => string.Empty
            };

            if (usePemFormat && type != RSAKeyType.Xml)
            {
                key = PemFormatUtil.GetPrivateKeyFormat(type, key);
            }

            return key;
        }

        /// <summary>
        /// Export RSA public key
        /// </summary>
        /// <param name="rsa"></param>
        /// <param name="type"></param>
        /// <param name="usePemFormat">Only valid if the public key type is PKCS#1 and PKCS#8.</param>
        /// <returns></returns>
        public static string ExportPublicKey(this RSA rsa, RSAKeyType type, bool usePemFormat = false)
        {
            var key = type switch
            {
                RSAKeyType.Pkcs1 => Convert.ToBase64String(rsa.ExportRSAPublicKey()),
                RSAKeyType.Pkcs8 => Convert.ToBase64String(rsa.ExportPkcs8PublicKey()),
                RSAKeyType.Xml => rsa.ExportXmlPublicKey(),
                _ => string.Empty
            };

            if (usePemFormat && type != RSAKeyType.Xml)
            {
                key = PemFormatUtil.GetPublicKeyFormat(type, key);
            }

            return key;
        }

        public static byte[] ExportPkcs8PublicKey(this RSA rsa)
        {
            var pub = rsa.ExportParameters(false);
            RsaKeyParameters rsaKeyParameters = new RsaKeyParameters(false, new BigInteger(1, pub.Modulus), new BigInteger(1, pub.Exponent));
            StringWriter sw = new StringWriter();
            PemWriter pWrt = new PemWriter(sw);
            pWrt.WriteObject(rsaKeyParameters);
            pWrt.Writer.Close();
            return Convert.FromBase64String(PemFormatUtil.RemoveFormat(sw.ToString()));
        }
    }
}