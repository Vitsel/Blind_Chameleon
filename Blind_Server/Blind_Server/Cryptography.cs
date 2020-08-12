using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BlindCryptography
{
    class Cryptography
    {
        public class AES256
        {
            private readonly RijndaelManaged aes;

            public AES256(int keySize = 256, CipherMode mode = CipherMode.CBC, PaddingMode pad = PaddingMode.PKCS7)
            {
                aes = new RijndaelManaged()
                {
                    KeySize = keySize,
                    Mode = mode,
                    Padding = pad,
                };
                aes.GenerateKey();
                aes.GenerateIV();
            }

            public AES256(byte[] key)
            {
                byte[] tmp = new byte[16];
                Array.Copy(key, tmp, 16);
                aes = new RijndaelManaged()
                {
                    KeySize = 256,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    Key = key,
                    IV = tmp
                };
            }

            public byte[] Encryption(byte[] plain)
            {
                byte[] encrypted;
                ICryptoTransform encryptor = aes.CreateEncryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        cs.Write(plain, 0, plain.Length);
                    encrypted = ms.ToArray();
                }
                return encrypted;
            }

            public string Encryption(string plain)
            {
                byte[] bPlain = Encoding.UTF8.GetBytes(plain);
                byte[] encrypted;
                ICryptoTransform encryptor = aes.CreateEncryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        cs.Write(bPlain, 0, bPlain.Length);
                    encrypted = ms.ToArray();
                }
                return Convert.ToBase64String(encrypted);
            }

            public byte[] Decryption(byte[] encrypted)
            {
                byte[] decrypted;
                ICryptoTransform decryptor = aes.CreateDecryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                        cs.Write(encrypted, 0, encrypted.Length);
                    decrypted = ms.ToArray();
                }
                return decrypted;
            }

            public string Decryption(string encrypted)
            {
                byte[] bEncrypted = Convert.FromBase64String(encrypted);
                byte[] decrypted;
                ICryptoTransform decryptor = aes.CreateDecryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                        cs.Write(bEncrypted, 0, bEncrypted.Length);
                    decrypted = ms.ToArray();
                }
                return Encoding.UTF8.GetString(decrypted);
            }
        }

        public class RSA
        {
            private readonly RSACryptoServiceProvider rsa;

            public string PrivateKeyXml
            {
                get
                {
                    return rsa.ToXmlString(true);
                }
            }
            public RSACryptoServiceProvider PrivateKeyObj
            {
                get
                {
                    return rsa;
                }
            }
            public string PublicKeyXml
            {
                get
                {
                    return rsa.ToXmlString(false);
                }
            }
            public RSACryptoServiceProvider PublicKeyObj
            {
                get
                {
                    RSACryptoServiceProvider tmp = new RSACryptoServiceProvider();
                    tmp.ImportParameters(rsa.ExportParameters(false));
                    return tmp;
                }
            }

            public RSA()
            {
                rsa = new RSACryptoServiceProvider();
                RSAParameters rsaParams = new RSAParameters();
                rsa.ImportParameters(rsaParams);
            }

            public byte[] Encryption(byte[] plain)
            {
                return rsa.Encrypt(plain, false);
            }

            public string Encryption(string plain)
            {
                byte[] bPlain = Encoding.UTF8.GetBytes(plain);
                byte[] encrypted = rsa.Encrypt(bPlain, false);
                return Convert.ToBase64String(encrypted);
            }

            public byte[] Decryption(byte[] encrypted)
            {
                return rsa.Decrypt(encrypted, false);
            }

            public string Decryption(string encrypted)
            {
                byte[] bEncrypted = Convert.FromBase64String(encrypted);
                byte[] decrypted = rsa.Decrypt(bEncrypted, false);
                return Encoding.UTF8.GetString(decrypted);
            }
        }
    }

    static class CryptoConst
    {
        public const string KEYPATH = @"./";
        public const string AESKEYFILE = "aes.key";
        public const string RSAKEYFILE = "rsa.key";
    }
}
