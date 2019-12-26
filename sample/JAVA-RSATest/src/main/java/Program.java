

import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import java.security.*;
import java.security.interfaces.RSAPrivateKey;
import java.security.interfaces.RSAPublicKey;
import java.security.spec.InvalidKeySpecException;
import java.security.spec.PKCS8EncodedKeySpec;
import java.security.spec.X509EncodedKeySpec;
import java.util.Base64;
import java.util.HashMap;

public class Program {

    public static void main(String[] args){
        try {
            loadPublicKeyByStr("MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEArbKqyR3KhETCGXxZrZURzEg01AaQXG3Jcba9aSWiRXrUAZKWdH1x7Iv0JmncSiAc0HPu/xyIeGRWT8p6/OteKnPQtiXYH+PXOQb2aDqxhw16Ns9XCe80eD0foCbtyoPl4lbLXILkjSAOf3WYPkJAem8FqXnfeFi1PEUyQMZs+6JvPFBQ7QUo6tXsXJSP6Z96RHdQgb3fezNX8qe/Cv16VSTjZeCs4cTKDsPgf9aBXdEOG4fvAO8QxszD9XyQsp6yHifNfpPNPv+MithK6Ke5AOT0ToPf0/WOs9mWvAwNcB0BEFK7sOgMGvnKg4cqtbPL6PoUdtsw+vQeLVhihThRtQIDAQAB");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * 从字符串中加载公钥
     *
     * @param publicKeyStr 公钥数据字符串
     * @throws Exception 加载公钥时产生的异常
     */
    public static RSAPublicKey loadPublicKeyByStr(String publicKeyStr) throws Exception {
        try {
            byte[] buffer = Base64.getDecoder().decode(publicKeyStr);
            X509EncodedKeySpec keySpec = new X509EncodedKeySpec(buffer);
            KeyFactory keyFactory = KeyFactory.getInstance("RSA");
            return (RSAPublicKey) keyFactory.generatePublic(keySpec);
        } catch (NoSuchAlgorithmException e) {

            throw new Exception("无此算法");
        } catch (InvalidKeySpecException e) {

            throw new Exception("公钥非法");
        } catch (NullPointerException e) {

            throw new Exception("公钥数据为空");
        }
    }

}
