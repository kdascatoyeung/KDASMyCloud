using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace KDTHK_DM_SP.utils
{
    public class SecurityUtil
    {
        private string _key;
        private string _iv;

        public string Key
        {
            set { _key = value.Length == 8 ? value : "-------K"; }
        }

        public string IV
        {
            set { _iv = value.Length == 8 ? value : "-------I"; }
        }

        public SecurityUtil()
        {
            _key = "-------K";
            _iv = "-------I";
        }

        public SecurityUtil(string newKey, string newIv)
        {
            this.Key = newKey;
            this.IV = newIv;
        }

        public string Encrypt(string value)
        {
            return Encrypt(value, _key, _iv);
        }

        public string Decrypt(string value)
        {
            return Decrypt(value, _key, _iv);
        }

        private string Encrypt(string toEncrypt, string sKey, string sIV)
        {
            StringBuilder sb = new StringBuilder();

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByte = Encoding.Default.GetBytes(toEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sIV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByte, 0, inputByte.Length);
                        cs.FlushFinalBlock();
                    }

                    foreach (byte b in ms.ToArray())
                        sb.AppendFormat("{0:X2}", b);
                }
            }

            return sb.ToString();
        }

        private string Decrypt(string toDecrypt, string sKey, string sIV)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByte = new byte[toDecrypt.Length / 2];

                for (int x = 0; x < toDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(toDecrypt.Substring(x * 2, 2), 16));
                    inputByte[x] = (byte)i;
                }

                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sIV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        try
                        {
                            cs.Write(inputByte, 0, inputByte.Length);
                            cs.FlushFinalBlock();

                            return Encoding.Default.GetString(ms.ToArray());
                        }
                        catch (CryptographicException)
                        {
                            return "N/A";
                        }
                    }
                }
            }
        }

        public bool ValidateString(string enString, string foString)
        {
            return Decrypt(enString, _key, _iv) == foString.ToString() ? true : false;
        }
    }
}
