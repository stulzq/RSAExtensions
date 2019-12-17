using System.Security.Cryptography;
using Xunit;

namespace RSAExtensions.UnitTests
{
    public class BigDataTests
    {
        [Fact]
        public void BigDataEncryptAndDecrypt_PKCS1_ShouldBeOk()
        {
            var data = "11111111111111111111111111111111111111111111111111111111111111111111";

            var rsa = RSA.Create(512);
            var encrypt = rsa.EncryptBigData(data,RSAEncryptionPadding.Pkcs1);
            var decrypt = rsa.DecryptBigData(encrypt, RSAEncryptionPadding.Pkcs1);
            Assert.Equal(data, decrypt);
        }

        [Fact]
        public void BigDataEncryptAndDecrypt_OaepSHA1_ShouldBeOk()
        {
            var data = "11111111111111111111111111111111111111111111111111111111111111111111";

            var rsa = RSA.Create(512);
            var encrypt = rsa.EncryptBigData(data, RSAEncryptionPadding.OaepSHA1);
            var decrypt = rsa.DecryptBigData(encrypt, RSAEncryptionPadding.OaepSHA1);
            Assert.Equal(data, decrypt);
        }

        [Fact]
        public void BigDataEncryptAndDecrypt_OaepSHA256_ShouldBeOk()
        {
            var data = "11111111111111111111111111111111111111111111111111111111111111111111";

            var rsa = RSA.Create(1024);
            var encrypt = rsa.EncryptBigData(data, RSAEncryptionPadding.OaepSHA256);
            var decrypt = rsa.DecryptBigData(encrypt, RSAEncryptionPadding.OaepSHA256);
            Assert.Equal(data, decrypt);
        }

        [Fact]
        public void BigDataEncryptAndDecrypt_OaepSHA384_ShouldBeOk()
        {
            var data = "11111111111111111111111111111111111111111111111111111111111111111111";

            var rsa = RSA.Create(1024);
            var encrypt = rsa.EncryptBigData(data, RSAEncryptionPadding.OaepSHA384);
            var decrypt = rsa.DecryptBigData(encrypt, RSAEncryptionPadding.OaepSHA384);
            Assert.Equal(data, decrypt);
        }

        [Fact]
        public void BigDataEncryptAndDecrypt_OaepSHA512_ShouldBeOk()
        {
            var data = "11111111111111111111111111111111111111111111111111111111111111111111";

            var rsa = RSA.Create(2048);
            var encrypt = rsa.EncryptBigData(data, RSAEncryptionPadding.OaepSHA512);
            var decrypt = rsa.DecryptBigData(encrypt, RSAEncryptionPadding.OaepSHA512);
            Assert.Equal(data, decrypt);
        }
    }
}