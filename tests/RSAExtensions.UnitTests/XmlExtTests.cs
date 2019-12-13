using System;
using System.Security.Cryptography;
using Xunit;

namespace RSAExtensions.UnitTests
{
    public class XmlExtTests
    {
        [Fact]
        public void XmlPrivateKeyExport_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportXmlPrivateKey();
            Assert.NotNull(key);
        }

        [Fact]
        public void XmlPublicKeyExport_ShouldBeOk()
        {
            var rsa = RSA.Create();
            var key = rsa.ExportXmlPublicKey();
            Assert.NotNull(key);
        }

        [Fact]
        public void XmlPrivateKeyImport_ShouldBeOk()
        {
            var rsa = RSA.Create();
            rsa.ImportXmlPrivateKey(@"<RSAKeyValue>
  <Modulus>on6QidIM9ALtnmCO3QfZ2tK5u4OZoaJmV2SAifjJfzIjhjLr3A2wMofga+muQX53PwIeV+6eu0dLK3abZkRAC6xkpdPvLypmvsyjoCNKCAFxSjvKWkn0cwHktFEAHIY/Mu5Jf2WwBvtcRHeu0gqG4BeistI6Bpl0erRQ9L8dm1bBAxWt4scRHfdL86q4avVqqBy3nDCJBoPH8HJtSJSosBShhIo7vuVU0DdJ1UWYouzFerEwO8x+RN++sG94pUTh6bnDxXGjGBvZZT+IlMe6zvRpC2x8SMXe1/xisI41K+Ls63CP3nXwzNq8IScGB9nkBHIKiKADhJzDof5rm7CFdQ==</Modulus>
  <Exponent>AQAB</Exponent>
  <P>yvaSaQMdNnkLzfGwDhoZL3fMOUnoxHxwRtJgtCijOOtFd9TBAk752I5tvmh2DyDNMDpGonfUpmIDz0syrptvp7ePBlrlpy6OxZh4tQgyJa5oWJcC26uO2+hmbQdiEYYB1CGAnWV6XQ65NxTFtuNgSHBsIBpy8ME1CMFDhngYACs=</P>
  <Q>zPTK4xNQXu82K+TD0t4guj4kT1WfGYAnYHPfNZwtMKmWFrfE/OYNJgtfWfG2WT8L9OfjfTx4zkhHetlk0OAOgodwSUUsG0DhbGL+nDD2YkW5Ir5hdibZyJWh04n4Bn/lH5VZGLRwax/h7k92LhOL49dZEyB3zmsRjaqgPhfJIN8=</Q>
  <DP>K6ayQHGSA9guyME1OyMzzXi3bI7PyAp3X1P5xmWDDUfUbfxM8oEnzQJ86dmvontMhhXSgTjCfHJSHXAv20vEzM52rUg5YiZqQGcVduHnXyFOgdcgnzwbgoJOHR7cYaZvmD8IWVGs6nyzKvyFtVrbp1i+eH0XwV3cWSCvtCj6CHc=</DP>
  <DQ>ZrBvxv4yUp6AAdYI12o785SXFLjNkjVHhWgI+g9aBPuzG4bPx/ZruBgSmjolJuoTz40vydu2m4RTbBXoEU9xdazucYea5bzINUoUT6WojOxqKiJBKrWkgH+YKSkDgB4sanqlvV8KxGGhDYn6qHNar7mCA7dMz7uNe/F1gCbiuvk=</DQ>
  <InverseQ>Hi6TMDUtCSkyrwn4mteY3+qh7HobJIliKzhf5jiNLi36ZkEAlBdFoueS/+lS9xYV6S4WoCzDIHBR75L1mrHFu7pAAGPGMNFo1+y3ZkCCTObX77faVc7qCGmqDdN9F4rv2YQktDU6oLy9IDf7NAN53+iywvYjZcPcv2ASXNSBx9o=</InverseQ>
  <D>n7PapMnAF1aFaaIm5w+fStTO3H+zz8tH4F6Tgob0qsGBbpS/gNAnOxKWPBk4PYBo/JE9d1i7wv6H35i7lKBBffeaF+0a5/U5dA62Rl5IlWOtj7MB5wlGan4S5DGz9VTv6kOOEtrDTalf/p7OP/s+oiI4sp2xj+jkNPDhnBn1pEPnljuOSwQrdORXZwUObOHiEqHgMEwphh//3qa04R1QlJXckcvAIBRYETT/mqef6lzwu/FLCpCNxNJhVUwXw7pdqzuDiXQY3k2OxYWU+sSVe8HRBZYy/ZAVGHG704UpnLpwLAKS1vuaGSYQJW7GWdf5PEN3fBVKrbNMzh8VzKKxZQ==</D>
</RSAKeyValue>");
        }

        [Fact]
        public void XmlPrivateKeyImport_MissingElement_ShouldBeExp()
        {
            var rsa = RSA.Create();
            Assert.Throws<Exception>(() =>
            {
                rsa.ImportXmlPrivateKey(@"<RSAKeyValue>
  <Modulus>on6QidIM9ALtnmCO3QfZ2tK5u4OZoaJmV2SAifjJfzIjhjLr3A2wMofga+muQX53PwIeV+6eu0dLK3abZkRAC6xkpdPvLypmvsyjoCNKCAFxSjvKWkn0cwHktFEAHIY/Mu5Jf2WwBvtcRHeu0gqG4BeistI6Bpl0erRQ9L8dm1bBAxWt4scRHfdL86q4avVqqBy3nDCJBoPH8HJtSJSosBShhIo7vuVU0DdJ1UWYouzFerEwO8x+RN++sG94pUTh6bnDxXGjGBvZZT+IlMe6zvRpC2x8SMXe1/xisI41K+Ls63CP3nXwzNq8IScGB9nkBHIKiKADhJzDof5rm7CFdQ==</Modulus>
  <P>yvaSaQMdNnkLzfGwDhoZL3fMOUnoxHxwRtJgtCijOOtFd9TBAk752I5tvmh2DyDNMDpGonfUpmIDz0syrptvp7ePBlrlpy6OxZh4tQgyJa5oWJcC26uO2+hmbQdiEYYB1CGAnWV6XQ65NxTFtuNgSHBsIBpy8ME1CMFDhngYACs=</P>
  <Q>zPTK4xNQXu82K+TD0t4guj4kT1WfGYAnYHPfNZwtMKmWFrfE/OYNJgtfWfG2WT8L9OfjfTx4zkhHetlk0OAOgodwSUUsG0DhbGL+nDD2YkW5Ir5hdibZyJWh04n4Bn/lH5VZGLRwax/h7k92LhOL49dZEyB3zmsRjaqgPhfJIN8=</Q>
  <DP>K6ayQHGSA9guyME1OyMzzXi3bI7PyAp3X1P5xmWDDUfUbfxM8oEnzQJ86dmvontMhhXSgTjCfHJSHXAv20vEzM52rUg5YiZqQGcVduHnXyFOgdcgnzwbgoJOHR7cYaZvmD8IWVGs6nyzKvyFtVrbp1i+eH0XwV3cWSCvtCj6CHc=</DP>
  <DQ>ZrBvxv4yUp6AAdYI12o785SXFLjNkjVHhWgI+g9aBPuzG4bPx/ZruBgSmjolJuoTz40vydu2m4RTbBXoEU9xdazucYea5bzINUoUT6WojOxqKiJBKrWkgH+YKSkDgB4sanqlvV8KxGGhDYn6qHNar7mCA7dMz7uNe/F1gCbiuvk=</DQ>
  <InverseQ>Hi6TMDUtCSkyrwn4mteY3+qh7HobJIliKzhf5jiNLi36ZkEAlBdFoueS/+lS9xYV6S4WoCzDIHBR75L1mrHFu7pAAGPGMNFo1+y3ZkCCTObX77faVc7qCGmqDdN9F4rv2YQktDU6oLy9IDf7NAN53+iywvYjZcPcv2ASXNSBx9o=</InverseQ>
  <D>n7PapMnAF1aFaaIm5w+fStTO3H+zz8tH4F6Tgob0qsGBbpS/gNAnOxKWPBk4PYBo/JE9d1i7wv6H35i7lKBBffeaF+0a5/U5dA62Rl5IlWOtj7MB5wlGan4S5DGz9VTv6kOOEtrDTalf/p7OP/s+oiI4sp2xj+jkNPDhnBn1pEPnljuOSwQrdORXZwUObOHiEqHgMEwphh//3qa04R1QlJXckcvAIBRYETT/mqef6lzwu/FLCpCNxNJhVUwXw7pdqzuDiXQY3k2OxYWU+sSVe8HRBZYy/ZAVGHG704UpnLpwLAKS1vuaGSYQJW7GWdf5PEN3fBVKrbNMzh8VzKKxZQ==</D>
</RSAKeyValue>");
            });
        }

        [Fact]
        public void XmlPrivateKeyImport_FormatError_ShouldBeExp()
        {
            var rsa = RSA.Create();
            Assert.Throws<Exception>(() =>
            {
                rsa.ImportXmlPrivateKey("xxxxxxxxxxx");
            });
        }

        [Fact]
        public void XmlPublicKeyImport_ShouldBeOk()
        {
            var rsa = RSA.Create();
            rsa.ImportXmlPublicKey(@"<RSAKeyValue>
  <Modulus>tCqFSO2gDg/wVTOVU0SfXlL+z+tvxLTtR6GXhm5hXy6Qbhtw1YtD++MNM3xYEjuyhsUiEpbni1zFIAce+gjOGJ+ZlnrG1i56cf8OODTFHQovui+/KJ0BRlFM6Wp7ypNTPFV3+r28pb6lsCiTFdVeKt+BBWaOW3eXpNZ/RsDW0Tfee6cG1z3ro5IoliVHrE30jhQ9OQ9GLxqzplIqpzigNwj9de0hK2yriXDfCr4Rz9aCPGftSgRTeEjRp2zyqijUhsvwlDBTFiJylz8/PKdLVuaG+1ndvEspPFYMJ2nIive25DSyJH6TolARGNON61//XwWJB1Q62YcKcidLhmXtkQ==</Modulus>
  <Exponent>AQAB</Exponent>
</RSAKeyValue>");
        }

        [Fact]
        public void XmlPublicKeyImport_MissingElement_ShouldBeExp()
        {
            var rsa = RSA.Create();
            Assert.Throws<Exception>(() =>
            {
                rsa.ImportXmlPublicKey(@"<RSAKeyValue>
  <Modulus>tCqFSO2gDg/wVTOVU0SfXlL+z+tvxLTtR6GXhm5hXy6Qbhtw1YtD++MNM3xYEjuyhsUiEpbni1zFIAce+gjOGJ+ZlnrG1i56cf8OODTFHQovui+/KJ0BRlFM6Wp7ypNTPFV3+r28pb6lsCiTFdVeKt+BBWaOW3eXpNZ/RsDW0Tfee6cG1z3ro5IoliVHrE30jhQ9OQ9GLxqzplIqpzigNwj9de0hK2yriXDfCr4Rz9aCPGftSgRTeEjRp2zyqijUhsvwlDBTFiJylz8/PKdLVuaG+1ndvEspPFYMJ2nIive25DSyJH6TolARGNON61//XwWJB1Q62YcKcidLhmXtkQ==</Modulus>
</RSAKeyValue>");
            });
        }

        [Fact]
        public void XmlPublicKeyImport_FormatError_ShouldBeExp()
        {
            var rsa = RSA.Create();
            Assert.Throws<Exception>(() =>
            {
                rsa.ImportXmlPublicKey("xxxxxxxxxxx");
            });
        }
    }
}
