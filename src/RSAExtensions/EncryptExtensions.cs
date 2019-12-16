using System;
using System.Security.Cryptography;
using System.Text;

namespace RSAExtensions
{
    public static class EncryptExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rsa"></param>
        /// <param name="data"></param>
        /// <param name="padding"></param>
        /// <param name="connChar"></param>
        /// <returns></returns>
        public static string EncryptBigData(this RSA rsa,string data, RSAEncryptionPadding padding,char connChar='$')
        {
            var keySize = rsa.KeySize;

            var splitLength = 0;

            if (data.Length > keySize)
            {
                splitLength = keySize;
            }

            var sb = new StringBuilder();

            var splitsNumber = Convert.ToInt32(Math.Ceiling(data.Length * 1.0 / splitLength));

            var pointer = 0;
            for (int i = 0; i < splitsNumber; i++)
            {
                var currentStr = data.Length < pointer + splitLength ? data.Substring(pointer, data.Length - pointer) : data.Substring(pointer, splitLength);

                sb.Append(Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(currentStr), padding)) + connChar);
                pointer += splitLength;
            }

            return sb.ToString();
        }
    }
}