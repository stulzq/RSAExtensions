using System;
using System.Security.Cryptography;
using Xunit;

namespace RSAExtensions.UnitTests
{
    public class ExportKeyExtTests
    {
        [Fact]
        public void ExportPkcs1PrivateKey_WithoutPEM_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportPrivateKey(RSAKeyType.Pkcs1);
            
            Assert.NotNull(key);
        }

        [Fact]
        public void ExportPkcs1PrivateKey_WithPEM_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportPrivateKey(RSAKeyType.Pkcs1,true);

            Assert.NotNull(key);
            Assert.StartsWith("-----BEGIN RSA PRIVATE KEY-----",key,StringComparison.Ordinal);
            Assert.EndsWith($"-----END RSA PRIVATE KEY-----{Environment.NewLine}", key);
        }

        [Fact]
        public void ExportPkcs8PrivateKey_WithoutPEM_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportPrivateKey(RSAKeyType.Pkcs8);

            Assert.NotNull(key);
        }

        [Fact]
        public void ExportPkcs8PrivateKey_WithPEM_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportPrivateKey(RSAKeyType.Pkcs8, true);

            Assert.NotNull(key);
            Assert.StartsWith("-----BEGIN PRIVATE KEY-----", key, StringComparison.Ordinal);
            Assert.EndsWith($"-----END PRIVATE KEY-----{Environment.NewLine}", key);
        }

        [Fact]
        public void ExportPkcs1PublicKey_WithoutPEM_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportPublicKey(RSAKeyType.Pkcs1);

            Assert.NotNull(key);
        }

        [Fact]
        public void ExportPkcs1PublicKey_WithPEM_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportPublicKey(RSAKeyType.Pkcs1, true);

            Assert.NotNull(key);
            Assert.StartsWith("-----BEGIN RSA PUBLIC KEY-----", key, StringComparison.Ordinal);
            Assert.EndsWith($"-----END RSA PUBLIC KEY-----{Environment.NewLine}", key);
        }

        [Fact]
        public void ExportPkcs8PublicKey_WithoutPEM_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportPublicKey(RSAKeyType.Pkcs8);

            Assert.NotNull(key);
        }

        [Fact]
        public void ExportPkcs8PublicKey_WithPEM_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportPublicKey(RSAKeyType.Pkcs8, true);

            Assert.NotNull(key);
            Assert.StartsWith("-----BEGIN PUBLIC KEY-----", key, StringComparison.Ordinal);
            Assert.EndsWith($"-----END PUBLIC KEY-----{Environment.NewLine}", key);
        }
    }
}