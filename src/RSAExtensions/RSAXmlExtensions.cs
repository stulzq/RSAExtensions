using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace RSAExtensions
{
    public static class RSAXmlExtensions
    {
        public static void ImportXmlPrivateKey(this RSA rsa, string privateKey)
        {
            var pri = new RSAParameters();
            try
            {
                XElement root = XElement.Parse(privateKey);
                //Modulus
                var modulus = root.Element("Modulus");

                //Exponent
                var exponent = root.Element("Exponent");
                //P
                var p = root.Element("P");
                //Q
                var q = root.Element("Q");
                //DP
                var dp = root.Element("DP");
                //DQ
                var dq = root.Element("DQ");
                //InverseQ
                var inverseQ = root.Element("InverseQ");
                //D
                var d = root.Element("D");

                pri.Modulus = Convert.FromBase64String(modulus.Value);
                pri.Exponent = Convert.FromBase64String(exponent.Value);
                pri.P = Convert.FromBase64String(p.Value);
                pri.Q = Convert.FromBase64String(q.Value);
                pri.DP = Convert.FromBase64String(dp.Value);
                pri.DQ = Convert.FromBase64String(dq.Value);
                pri.InverseQ = Convert.FromBase64String(inverseQ.Value);
                pri.D = Convert.FromBase64String(d.Value);
                
                rsa.ImportParameters(pri);
            }
            catch (Exception e)
            {
                throw new Exception("The xml private key is incorrect.", e);
            }
        }

        public static void ImportXmlPublicKey(this RSA rsa, string publicKey)
        {
            var pub = new RSAParameters();
            try
            {
                XElement root = XElement.Parse(publicKey);
                //Modulus
                var modulus = root.Element("Modulus");
                //Exponent
                var exponent = root.Element("Exponent");

                pub.Modulus = Convert.FromBase64String(modulus.Value);
                pub.Exponent = Convert.FromBase64String(exponent.Value);

                rsa.ImportParameters(pub);
            }
            catch (Exception e)
            {
                throw new Exception("The xml public key is incorrect.", e);
            }
        }

        public static string ExportXmlPrivateKey(this RSA rsa)
        {
            var pri = rsa.ExportParameters(true);

            XElement privatElement = new XElement("RSAKeyValue");
            //Modulus
            XElement primodulus = new XElement("Modulus", Convert.ToBase64String(pri.Modulus));
            //Exponent
            XElement priexponent = new XElement("Exponent", Convert.ToBase64String(pri.Exponent));
            //P
            XElement prip = new XElement("P", Convert.ToBase64String(pri.P));
            //Q
            XElement priq = new XElement("Q", Convert.ToBase64String(pri.Q));
            //DP
            XElement pridp = new XElement("DP", Convert.ToBase64String(pri.DP));
            //DQ
            XElement pridq = new XElement("DQ", Convert.ToBase64String(pri.DQ));
            //InverseQ
            XElement priinverseQ = new XElement("InverseQ", Convert.ToBase64String(pri.InverseQ));
            //D
            XElement prid = new XElement("D", Convert.ToBase64String(pri.D));

            privatElement.Add(primodulus);
            privatElement.Add(priexponent);
            privatElement.Add(prip);
            privatElement.Add(priq);
            privatElement.Add(pridp);
            privatElement.Add(pridq);
            privatElement.Add(priinverseQ);
            privatElement.Add(prid);

            return privatElement.ToString();
        }

        public static string ExportXmlPublicKey(this RSA rsa)
        {
            var pub = rsa.ExportParameters(false);

            XElement publicElement = new XElement("RSAKeyValue");
            //Modulus
            XElement pubmodulus = new XElement("Modulus", Convert.ToBase64String(pub.Modulus));
            //Exponent
            XElement pubexponent = new XElement("Exponent", Convert.ToBase64String(pub.Exponent));

            publicElement.Add(pubmodulus);
            publicElement.Add(pubexponent);

            return publicElement.ToString();
        }
    }
}