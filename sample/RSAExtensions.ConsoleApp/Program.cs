using System;
using System.Security.Cryptography;

namespace RSAExtensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = RSA.Create();

            Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Xml,true));
            Console.WriteLine("-------------------------------");
            Console.WriteLine(rsa.ExportXmlPrivateKey());

            rsa.ImportPrivateKey(RSAKeyType.Pkcs1, @"-----BEGIN RSA PRIVATE KEY-----
MIIEpAIBAAKCAQEAy0KT5Zrfy89V60VdIEktKKVh8Tpil4Fw7h+/4ZvWQrOJhQ5h
xpL/2BJkg4QEbHlP6ItF9HduIYMlp+vmpPi1ysG2mkRe+7is9AnLAnf6/MvzJFFF
F/Onc+eegnfRxvxJ8aTx+yE8QwwOeOkfLds9kTnj2UQCND59HtB2ksec0r88WdOS
6XtCCYTQPYovnKvPNW859rd/e8qNPQ6vCFXjmNTGYH/tvAXqAq5C3jMs3ayVEbq0
l5Qn1itSTM5gdiWV5cR2hLDb7J61AMPOQq5tdLxL5s/lJ/gXyLl1e0mEZfO0oQlz
XFqsarkXJYjWyQhnUpG5S5cUqVeLicSIaW+dWQIDAQABAoIBAQCseM/6UlJ4JHSp
cHA3ByDUjpDvGjWyjVmAFVzCWXOTobidOLjqwK1rcR/tIMaILOALWLKBYB4JPblk
JZ3OemP3qiwB9uYJ/ohzgyPJ8nj8rSqhtHxGeK+sf+tWlclhaY5tByN1jpwN4Fsf
aeDVDmXNpyuZnkWogyW0UftrTQnbIHs4clsE4tzxd9BtP7iWDxT/9qBHf7w10+r8
kJBCP0O7pX9vkS24E8BCQR8uw2Iv/920QTdmUr7CB406y2ViWupNGLJzJIJ6prrT
r1oQ1hUHJl+VcDGE042nTGeXxOjr1CoSJVG9w+Vp/zea7z/+N7FjMjbb4458LGEa
MiomAdnJAoGBAOYCA6srqfLgLtiJNz0/X3oEYC4+gJVlgpBT2uBJSc/joaFa4blB
c08Mm55hUNGbwExNabWcVeqI6Mhnb9qKz4cp0iasMX/pLVdrYnOSHbTSE4E8U3KC
CYhiq6mzje9JN3yO4BOB1W8oDPqiCU7oIYmPqnc9YO3WY3Ai4G0GN5cPAoGBAOI6
xB0SYAJKd95AXIgub6oOhm55GcHaxEdDp16qf9h5olnIQCsQQMD1WSuqSlhLs1co
JLZJBeNFvIQfIYRRg4l46ka7RSeXwKF+BXhC+7KeGG6dj4B7R7yZ2iGuNWynRIKn
vbCtOUty6fmSjo1jAc7ErqArM8+1eATLz+VlpkUXAoGBANAddHpV6NF1HY4aIhxO
EjLScMCHF0uWbNvws/QK/DmZiy73j5RTb2VQUCKvhTQTzJx90y9bhLXRKWfjh+bj
gMGZCqipV6SYNMmLxaoyxKRPDQz7q7nJhZydQxwq9jtUMVuH36Jm8NtCDvRc1zVJ
fsb8ck6v/9tUB+d39z9Ox8/rAoGAAInbRaZxjA/ZUTIeBkT2BxWZxFGNeiSnKvRC
RbtqKn2/oS8U2AVl4g+zcqMpIiSr/J0f2T87QFs+I6JfVg1Lntwm0pxHgdyenMPM
B4lBSB+QN1MwsEGa3hwPpNzhS6zqQNVdYjpHVKKlY+6xYCzIKFHXiJIRwYDRFFHX
4NfpGWkCgYBOtrmreUNmPrDJeBEkCmLbnLJwB8uGDEbjQeljrAyJT9lrNgTCyxZ8
03bsgeO/CEcXTUXkLX0p5j0GO1l1V1LXiqTPpVfe0idq2u7r9erOWjNy6WAiM3nb
eHySyXvTRNnOoqtl/H7ZGZMpJu/Qn+nJcFl2DECoJSrGBZyzCBhDpw==
-----END RSA PRIVATE KEY-----", true);
        }
    }
}
