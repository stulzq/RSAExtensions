# RSAExtensions

## 1. 简介

[![Latest version](https://img.shields.io/nuget/v/RSAExtensions.svg)](https://www.nuget.org/packages/RSAExtensions/)

RSAExtensions 是一个用于 .NET Core 的 RSA 算法增强扩展，它为RSA对象增添了一些扩展方法，支持的平台如下：

| 平台名称      | 支持版本号 |
| ------------- | ---------- |
| .NET Core     | \>=3.0     |
| .NET Standard | \>=2.1     |

功能如下：

- 提供以前Framework有的XML格式的密钥导入和导出
- 提供对PKCS#1、PKCS#8 PEM格式导入和导出支持
- 提供对PKCS#1、PKCS#8、XML格式的统一导入和导出
- 提供对大数据分段加密的支持

## 2. 测试

全范围覆盖测试，保证每个API准确.

![image-20191216173430391](assets/unittest.png)

## 3. 安装

从Nuget安装

````shell
dotnet add package RSAExtensions
````

## 4. 使用

````csharp
using System.Security.Cryptography;

var rsa=RSA.Create();
````

### 4.1 导出

#### PKCS#1 导出

````csharp
rsa.ExportPrivateKey(RSAKeyType.Pkcs1); //私钥
rsa.ExportPublicKey(RSAKeyType.Pkcs1); // 公钥
````

私钥输出：

````
MIIEpAIBAAKCAQEAv4pVuabfkk1NxEpIz4GYMpG69hyJDXAFJAIuUP3qCIhq081KRwrWW+0qQZp6MMTHHA/O+rHHTR6vfGBOo6yxcs9c4QCbnt/RhQ+bOmLizTJURiFrbgFU9q8dlpJ8OaoSBE3M2dY6wMhck+vEGSr1w7Fm+wH+IPPyKfNynPDYs3rKzNyHJfre62Vf23tB/Zd+7UC0PAEing7uERZdrRfloy95v8o2kVBIk4v2YUjEpLaMDbytBo++wMbyTHqsHtJKlCfxAZ+sb7VKQx8JlNEMals4k8gwjCTtoum34jgscb7CQ1aleAskTrQO2zkQINssrN/sr3WlEZ4ZdNXXVb/JhQIDAQABAoIBAF5o4i47CXIEdnNtJgxZ1Vn/qMbMc+VStMX16Tx0m1mPXBB/3L+9oMD42l4xtU66f2XeiOfanuDtYhQNKFXWtjRf72jcMtiRe6V5dsrFmQMJbq6OpHQ5ZdadpBjmpSKLKIxEiNdKl/UUDUW/7Q12tmK524eXiNpXQ6LX40NmF3oHDwMb7ZGnynFBKdA4ZDZWcVpL1eGY9xTJnpAmLRsI4UXBVeSIKZYZAo4I4FhvWr/mkESiWhBGCGrFMQB75t1x6wTqHPBoWjo9HJrSW66tbEeIdwNbpxzlaYqcOMd+Uk6P38lCE5J6rxRCMXjvehEqZmAYswfMNS5a5o2a/xEHElUCgYEA4NTyPS+aQDP9Vu8fpsbCyfxiPLSam9JUJm2ON3/0C6uomYVHnL72AgM7srmmQB4cA6bbvscjB5oB504bQ73ppi56SFnvjhQckCAtU0VPTtOVSUYBOQGvhCY0Lr+AJHCKYCVEZEWdGFObVTApA+QXwHlpheSe+fuMZkIjEiuZX2cCgYEA2hfoopk1b6RNbBvp9X1TfiZYW/x6Jrs9ebr3z08lawtLeSJAXPS37XqYgVUTMXxs7mcIP7AHmGuFlu9nOA6sVF1E2C1I3f6YMH8OaZCiH0/e3swqyTkYyiHBmCnh2lWGVyf8jK+OF0Y9KI+omGiyFiPTco6VS6Q16Ozd/NJK+DMCgYEAtjB5V9GiSpKWoYLGgEwifrFRHeYwP0LSRA2VKC48odRpnHYfUMqB6aGbF7pPGTgM9XyaJ1+RaFCJaFmnyF413x9cohKXB+gOOVCJyiepG7RjDex3gy11gD3BHXy7J0w3JbAtWp/6rELb5c1P/0IvaR45v3FCzknkPN0tNEU2VNMCgYEAtlOIm+6jurrMMxY/CImGtI7QDc7MO/cLFOqW44xSRuRBa3qT/mJkJbf5KR57lkJkOwaN4diC8QzquN1aGIZD0Z/Lv0JUiaqfhuOho+VTdAPs2awsFN+T9uAzncdd1o7raY+3VdIqYxDIblFzbD8Squm2iy3iaENXAmyLxSH1pPsCgYAXZincMY50iTmF9qYaS9xs44d3riKRQpty97W+igW5MqFMmmajfy8QShVliG1cU10Hsvz0hAZ6SK5gl+Zp6CHrveuEr69+aee6Xjp3hiJKCEiId9ahCpr8EBPWYTi22azBzgGiXseqMEI2UR9SS6K7OZ2TRNwWOERuBsabERZQhQ==
````

#### PKCS#1 PEM 导出

````csharp
rsa.ExportPrivateKey(RSAKeyType.Pkcs1,true);//私钥
rsa.ExportPublicKey(RSAKeyType.Pkcs1,true);//公钥
````

私钥输出：

````
-----BEGIN RSA PRIVATE KEY-----
MIIEpAIBAAKCAQEAtffhsp2hu1b0isDlYZ2UHd5NPLGHJYwDzWFM29EiXZq3pHDY
CFNF5jJ+h8U4e10e9XDvVF6X02OLQVjVCZVlikRe5VmKGOU+azL5ojg1MbLOqEJr
fd3f/vxcZ4sCIxdWNgHefPixneNldIULBor9n4IlB5so54YdPZLXxLwSXJczTbeG
LuMRw2plKZpp8hLZTLeR42g0aIBUbBanDZuoP2ztjFthUTf+E7PbI4hmFhL4nszO
/9KuJEvlnLtQF9shHZ5ERvgHXFbHpM9e1nz4Yr+eaTWxVF6vNBicKFrTgMNtYtS/
6x004yVmpXdeHUBDwerIJwS7AJLXX0BC4mlDGQIDAQABAoIBADxo75+5nyCvjH2n
7j7K7oo/68pTcXdwlS6Qt9BeDJegrojEAaQ56QG0D7eJLOgfkRCQjpOm16aQ7IEk
OY118IDHk+12HVeIe4FhKejF2jsGjn7jlgXyK9Pd+dtSFcKKk89YLYG1mlm9TUgy
hueEKxDSRvLQevLp3jk7z6/7c+kSpPUrsreWyq6qP+lwfmPa6k6uAwEpHKfGKmCC
Sj3vnC2jBfG89RZFhvB9VUXqDs1Yppi1anFlymB7eJMOu33SG9hqHK/AwJpv1qM3
ONebjyZ2rrrCxhMuR3luDdgACHpINOyeb8zkR0v+24aqHGLs3V31bGkYqITJXSkm
udNHM2UCgYEA8cpokD3GMolB8npIDw7DcwoAW9J3rD44EDHpak+H+wNbUxHzcrwc
ylEcIkbM5hiIyEsmkWVwsqM/UQ9v+Fl/h6AlqPE4ai4D/pbfWnlPxPuTGzm/wpWR
sXcZJ+EAWn6MR+6fm1KeAsCRs8rBL5OKhFRXOzwdmulVg8jNGq4ijycCgYEAwKl7
gmSj7zlY0ATesawZVM3cSmV3rp5uCN61jZkY1zzOw4uiD0dDyCIhzYJc9fp2pUSf
plNYv58+StdoI+gJ8fd9Cp9afW7kTHXM8+SjOEwsECQKmiJZ+re+biXYJ60T9moJ
iDGcdNvS/s/F8rSqdd31gzdNALRqYWIvZSFVA78CgYBotForfFTDtaSVOFbUDnSc
8IvPN4kTUa49dR+7Jc2g6Yc2peNioAtnoVApl7dLPPyen8yH0gHHmeHlXGYEid0s
AjHMwwjHEj4wlW0LZNUiXD8L3yonPVXmH8kI9+qLRZnB3JfJTzGVx4ZQ8VBPJfkp
7MwJnrLDTp/1fZM0JoxYqQKBgQCrweykMIidqqhsuwq1ptHmcqhjgtYRzJgYPEPq
+oPUzxcd6YwOxt+8ugEcr42klSfU6rrRkxhZrOPh4Ouspx7GonbNU4der8/EAnk3
Lav9cpsNwLPa+ajyBYE1vXNY28oiMiJRUrlCzP7rv9ufJkWZUsmfs1tot27nZpsO
M4sRDQKBgQDvnddTAbTX+GAfkGS4t7iYPuwk2U1YplnT75fgvmgbm7Ett4PbeCBb
FLNeGxKodTChqO50+q82qasO00He5XGo+aSiwVigxjtI/5QZGjl9WxcWUwLrSTS4
lABg9PGeOzUZSgAVxYzXhJ2kkMtj8NhVqRvAEegjKc/tML6SDJ4coQ==
-----END RSA PRIVATE KEY-----
````

#### PKCS#8 导出

````csharp
rsa.ExportPrivateKey(RSAKeyType.Pkcs8);//私钥
rsa.ExportPublicKey(RSAKeyType.Pkcs8);//公钥
````

私钥输出：

````
MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDLGWghUU/jAMivM53r6M01dtHIQwtDlDhfNLot5keKXRA0PD/yZ3ZZoi7W1ffvyfcuw2Db8nTGGIThFfESi7eyQdrLWqC7x8MppRtL6pYyercyApC4UhFBLTF4oUX/vecK9bHw/SuQGJtDfilZIxIfNZWpVrYpzEyAWpI6ix+pUlCA5LM9q3C6JbLsiMEvX3ypafoYUeOwx4ydEn3NwoR8EpeLzi3OHfcvo+m4yOUrLZXlMhDnMgPwyew4TOW/NsqaBvJJ+9r5hF/dcEQmpA8uvO6HJU7pClbwm0QjjjKdC/r//MHuiOFdv5b5bU0MJQGJ09tEWkEfUr/TqI2wZm/hAgMBAAECggEBAMVXX32YI3ZfqZ/LGLRD1TkQxc+/jS9R0uB3PDwjF/pSaM9Ih54Cd9WqJ7bp2upspLgUcYXldR+SbXLDviUWCxyyrmSPH8S12mUZn4dJXj2YTW7TXUkrvMZGol4i3gAbxmY4y3hslqqBrkOLT6Pj1tTqXQxYS9IbR24kExe9XLtIm/+3VcXRlW7AT2TZk1TRSjYB5OPmlYoPdQEZYk4ZL0NUNj1+HvQoeHX+b1iXJ08bP+KuTnJ+zxe6WG0x8x1cCpwOwGvEqMQ2SSyJihxw0969hPwwyeDDEWxkjaZdQt4I+aYE4KvLR75ixfkk6u5cknidmZjY0OCR2iLHbR40D/0CgYEA46+zjaa2cJEo1+7c8JSZHf+8/NAWAbo388caBIHlQ3tWDGVKbD0V+PsJPU3ZCZfIM0K1vBY0G/Ss/Pdn2CLVQwHHaVRMSAlpOdwzQdiao8dkT1B3zcVlzbInKbsc06C/3NCQZ+NKi1P2rlJ8u7tBq2Phbltwzu/KEfNe4vD2n7cCgYEA5Fr8WylpAF4o0LoOX1nZy4swvyOpG9a9yM9qilHeUVveIC7hEgNNe6kuasvmunPdF/8jOlcit2pBdg85Xu76h3g+AWK5cwnWwojeI3msAXpnej/VI5NkNGeTbJB64sX6PpmPvhMwApS6RRqpGttQ+qcO6lx6Vn5FF+jP8NxmvScCgYBC0nQd5Imyq8eS6BWLvfDaLw4mHGP5CdAWCZ8HJ6BDl9T/OlMHRT5HnlVt2oUSHaux76gqlVGhysNiUrH1avOwALunnAfvNGPfiVK5xnpMCt7TsEgY6hAguGJqCvJA4fKtOcDH3JsqHPBO5QKajjCNvniQzOFkuldRwV1duV6ILQKBgHrngZVrJ0l8ZElbKmslh/RmWPk3L0h9fq36/OOvhpGReW8m7BpuzqA1AXeXgPpva9sDhilbRqMjPFJXhVBUHWEWVYEXaqrA6+bOFYlQbkRpZhJFEulP5gnSiWVQKeOuHK7epZ/u4dMxy0NwQv3idqZBjeSTm4C7+2IP+wMvDNjXAoGBANM9wm6iiZOqZTCdMh/bnRDkChFTr8uLmbu5dtG8iXkGDhq0gX73GRrg4YL3R9oGSG/95zp5KThD94eAxZR1jrIChze77V6Y1urOMruUiluFIokoI94xUb7oh988yG2RSHzWQ3YzOGV1KqIf05j9JJvXZYcjUmB5yFWzPZVmDiwi
````

#### PKCS#8 PEM导出

````csharp
rsa.ExportPrivateKey(RSAKeyType.Pkcs8, true);//私钥
rsa.ExportPublicKey(RSAKeyType.Pkcs8, true);//公钥
````

私钥输出：

````
-----BEGIN PRIVATE KEY-----
MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDXuqAQz+MyeKuC
335rPshsHUFxLpZcBj97EiHq9qhvxMhLsMoa3YFvKlwktBoQWzZzgETls1N0H5E/
yhV+pljN4TIubfsOQ68TUfJkr9b+S1/25KwOwUmMndqaFb/vcYj1QtWTl65OXOWL
l3oKl7j2kwjmwtW8Smm97cEw15ijmRALP3qGvYyzL/YRIOHv+PmDpoMG0dedZRNz
u7hdhkU/UrlaRLvDLHyUJPkM+4SJHVUa2epYFMB7OX/b4ZQR0unxIBea2HAo8byG
qctOB41cXa6+t8dvRj2DhCXhMHGXKNU8DL9aALLmCbl2UTsJQyvNQ3FaT7TzQYsw
gOevjFttAgMBAAECggEBALltxOAukM91QZdAm917HbMwgmvS65M2G6Kht13LnoRT
1Qaac14cP4FaG9HArRaaEHe/LXlzZqxN5f+6qDcwrOxqQUP/bOiZ7QbiTUOWkWoL
R/VkITCdm6aumJQRVeVu5ZZLWGGA42agGv6duV0ZhPcM833GwwkRvUpv7rsY1i7n
ccUObhkv3ql8XjnCcz1rSSkf6W40+dp0pW2mCH6NPeT8kdtBH7mA/ZSK7ZMQbMGg
LNdCx069o91POKP/nZ9V9Ex2Bviic2TqpilC6Z/9EryxA0HszknUMX7Lnuhr7Fsb
n8wkvYLplebolTOrCy/athEZkGdwCrgdGFk7by/XsdECgYEA9BX0vnhr1d1A9rxz
YYt/Xt3DqqtnQ8ETe4CldI3/XIJ3CcMI4f52dAk+Jl9V4vHu4HRKODWjJ67FDExQ
Bu+FWUjk01rFSMmbsVJRenRyuGL4X5XTRwMCtcIcxfvYgttLVVpqCsDK2CredAxc
u+RZ5eI0/Y4gc+BKzDIbSy1LQ2sCgYEA4kJUQ4BlIQHD2CEj49ORL/WzWk01Wi9A
2ilQcVf/xbLeBJd04SemftHLF4ulKM6VZ4KyrTzewwM6rEw31fWo7dgxShwTdnMI
Hn3esTdZYK6O6zQ8PuEi/q4hTx4QYXDq63pKoDRTrkQAVZdTe0ujyczPXjdAKwYF
obd3sk606ocCgYA7tpdedZVkB7HZ6vaLOZZafgRdX3tu3vBGOY3AuvBrEFvQ3o7w
wtD1yEEVICOh1rAq5yg1IiIdFiuMu6qkV7qWwjeA4Wb8TJ4zPkFCpPRf2Y6Ly9qZ
N8pU7v0dDmTEdqOyaOEialH1ml87or6ZFN9NVw7BrSCRWKDT3bpBpP4RqwKBgQC/
i5u+kaILsWzVOikiJOgTDBTMa/Sw5rQmfTdm3TLhca3XgUknm+OuFXmz8zrdMxb0
zIbrdk64FbHET7otXo2m3ZHMxbwMWRIUjkbLDKqT2PORV2VxbjOsHEqCqlb/xxJ6
S8uFmQcGzvbhfvzjsoN0wfkEMA4Y3j5CTAn/X/Z1XQKBgGG4qDagG1unSkpNfHfu
qwjEjAkSR/pla4vJIaEaA94/gJ21upZfwjUUdRXJbk6W03OfSOlmy2zIeCguV+H/
UkMOcmBqVX/tbCQy7weCQwwHU4Dluy7xJIzrgYRXIuV+3zk2D63+LAK84+ksbL61
zCnaG86YfYxcClOZ/revxrnd
-----END PRIVATE KEY-----
````

#### XML 导出

````csharp
rsa.ExportPrivateKey(RSAKeyType.Xml);//私钥
rsa.ExportPublicKey(RSAKeyType.Xml);//公钥
````

私钥输出：

````
<RSAKeyValue>
  <Modulus>09Hvw+dbHzi8x+9A1b2S0/128nA61ZyiaazJcDCUety4yHg0cdp5NOnyH35njYR4u2XO5l4GptwzJQfkEzCNoAniofBkb/WMQjvUhJ30eVpa7p/aq+4cgnMYuwYRCOLAB3jpldzIvii1+BOr3oLeT+1blK9f8u3T5liIxV3DBFxEWbnhQWHMgYXpDBIV9cjVhLYZLznefoWZ8N9bVdg1aucgYSWiPbURdfZusyS2fUJgiDLu63KQw8Bhc9cIMnUh6fq2UIBMk1mg/zuKyuMzCM8FX/VvleXJwS11LAgkEhtkOKQXo2xB65+zxPAUl0mKWGKSP9gY8p0+cav4nFCSLQ==</Modulus>
  <Exponent>AQAB</Exponent>
  <P>6ZEU55sugjc/qcPW0u0fSxy5tJYI+8tFsKfw/5AAm4pq2SVfDQHkRODlv5Zr8DnFQz7WN2L7FL6f11qdIjO4/dF9oo5YlD+jlmTOdaZovNLT0w0KGnN3ChFnnyxyNSG33sxlwgUrBppY2W4Sh0rzNQ4VIBhGes6dHxuMg0hWCKM=</P>
  <Q>6ComYZkP5fJrT5tWNSTkb+UGyUwxquXWAgZB8GCkAzrc5t3QgPe+1W0bUSJOVddPX6mxx6yaM+ZMFc5pwdcyxYJ90+T/m2NNviMOC2fHB457OWr4HO0DloYHlWbniXfkOLGrWHshcbIEwbsYWnVYF3mOF2b/xDuDUB57B71Flu8=</Q>
  <DP>k9guL1zfV7W5KrC4btOCF32bX2AJV7kX5/amal6ww8QeVk19mTI1WBQz2c5RjMJEx4gi+PRCkqMHcr388QVkd+X/bMJF97FAz5YHyhkH+15IjzOVzaCBHXJe8TalJFSvmuwvDV1QGuHgk+FFATbENDUx0hsLofjfJC3AB+nl65k=</DP>
  <DQ>v80qvlDUuJUpILBlbSxYaTTeAWmoUtbkkfGXgj5k4aI8o6K3QgTrLKmh+sqLyxFBKvgnvp2TG7N0QkOwTYs7D795spgqr7Y/oQiW7sdCv7RviwUbi9Int7BtDXnhaUmaS1hFBalb/PEkSuUF/p2ZNHOg9yaJwRWlq4gy/jbZChM=</DQ>
  <InverseQ>EydINmQ+aX8+2W7ZxU66P+0XSYsA2M/m7eF0cn5B+N3E2TOYgwunWqjPksyprEtNlP/puf7li/g8G5j3fQ0Xy/KrVwR2emcvCZMqpjzkYhSn9KcVHUVJg/LHb7BDVx/uSZwj9Ok2qDX73PSa91DEsIPiKPQjkVw1QJJ19wlJMiQ=</InverseQ>
  <D>MzwYbp5LYCXtI78vQ4PzO+uXFdUnpfuZHU55+vUFNSKmX3cT2GYr4yyjMBL3ITflrA5YGUis+zdP96kM9cdMumUpuFnZMWuHXY3zPZCnTaMZU5a+4c9afgMw/CvfevK92BDbDzC0LarTOQopDE1DULns6O3ym2QDWTgY/QRM44StLMEaLjNdVhLS3lMZJPrMCtk1k044RStUkL/7yiLMUYtXV+Lpy/08dyHWdXfBcakusKw8EEZZ53skFeR6mkWT51wyKmBFf7D6rfUC+e282i8OGayu79zXvA0UutmUGa1Q9eAP8qsBrc/i++qa/X3JnfBrFyEwQBfQV3kiOM3T0Q==</D>
</RSAKeyValue>
````

### 4.2 导入

#### PKCS#1 导入

````csharp
rsa.ImportPrivateKey(RSAKeyType.Pkcs1, "<privateKey>"); //私钥
rsa.ImportPublicKey(RSAKeyType.Pkcs1, "<publicKey>"); //公钥
````



#### PKCS#1 PEM 导入

````csharp
rsa.ImportPrivateKey(RSAKeyType.Pkcs1, "<privateKey>",true); //私钥
rsa.ImportPublicKey(RSAKeyType.Pkcs1, "<publicKey>",true); //公钥
````

#### PKCS#8 导入

````csharp
rsa.ImportPrivateKey(RSAKeyType.Pkcs8, "<privateKey>"); //私钥
rsa.ImportPublicKey(RSAKeyType.Pkcs8, "<publicKey>"); //公钥
````



#### PKCS#8 PEM 导入

````csharp
rsa.ImportPrivateKey(RSAKeyType.Pkcs8, "<privateKey>",true); //私钥
rsa.ImportPublicKey(RSAKeyType.Pkcs8, "<publicKey>",true); //公钥
````

#### XML 导入

````csharp
rsa.ImportPrivateKey(RSAKeyType.Xml, "<privateKey>"); //私钥
rsa.ImportPublicKey(RSAKeyType.Xml, "<publicKey>"); //公钥
````

## 5. 大数据分段加密

> 下文所说的“长度”均为字节长度。

RSA算法的加密数据长度根据不同的填充算法，一般最多支持 Key 模长( modulus )相等长度的数据，如果超过这个长度将会需要对数据进行拆分加密。

**Key 模长=KeySize/8**

以下是我测试整理出来的 .NET Core 支持的填充算法的支持的加密数据长度：

| 填充算法   | 最小 KeySize | 最大加密数据长度 |
| ---------- | ------------ | ---------------- |
| Pkcs1      | 512          | 模长-11          |
| OaepSHA1   | 512          | 模长-42          |
| OaepSHA256 | 1024         | 模长-66          |
| OaepSHA384 | 1024         | 模长-98          |
| OaepSHA512 | 2048         | 模长-130         |

本组件已经封装好了分段加密，使用方法如下：


````shell
var encrypt = rsa.EncryptBigData(data, <填充算法>); //加密
var decrypt = rsa.DecryptBigData(encrypt, <填充算法>); //解密
````



