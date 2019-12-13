using System;
using System.Security.Cryptography;

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
            var key=string.Empty;
            switch (type)
            {
                case RSAKeyType.Pkcs1:
                    key = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
                    break;
                case RSAKeyType.Pkcs8:
                    key = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());
                    break;
                case RSAKeyType.Xml:
                    key = rsa.ExportXmlPrivateKey();
                    break;
            }

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
            var key = string.Empty;
            switch (type)
            {
                case RSAKeyType.Pkcs1:
                case RSAKeyType.Pkcs8:
                    key = Convert.ToBase64String(rsa.ExportRSAPublicKey());
                    break;
                case RSAKeyType.Xml:
                    key = rsa.ExportXmlPublicKey();
                    break;
            }

            if (usePemFormat && type != RSAKeyType.Xml)
            {
                key = PemFormatUtil.GetPublicKeyFormat(type, key);
            }

            return key;
        }
    }
}