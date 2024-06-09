namespace Tubes3_let_me_seedik;

using System;
using System.Text;

public class XORChiper
    {
        public string XORChiperText(string text, string key)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                result.Append((char)(text[i] ^ key[i % key.Length]));
            }

            return result.ToString();
        }

        public string Encrypt(string text, string key, int maxLength = 16)
        {
            string xorText = XORChiperText(text, key);
            Console.WriteLine($"XOR Text: {xorText}"); 
            byte[] xorBytes = Encoding.UTF8.GetBytes(xorText);
            string base64Text = Convert.ToBase64String(xorBytes);

            if (base64Text.Length > maxLength)
            {
                base64Text = base64Text.Substring(0, maxLength);
            }

            return base64Text;
        }

        public string Decrypt(string base64Text, string key)
        {
            byte[] xorBytes = Convert.FromBase64String(base64Text);
            string xorText = Encoding.UTF8.GetString(xorBytes);
            return XORChiperText(xorText, key);
        }

        public string XORChiperTextToBase64(string text, string key)
        {
            string xorResult = XORChiperText(text, key);
            byte[] bytes = Encoding.UTF8.GetBytes(xorResult);
            return Convert.ToBase64String(bytes);
        }

        public string Base64ToXORChiperText(string base64Text, string key)
        {
            byte[] bytes = Convert.FromBase64String(base64Text);
            string xorResult = Encoding.UTF8.GetString(bytes);
            return XORChiperText(xorResult, key);
        }


        public string XORChiperTextToHex(string text, string key)
        {
            string xorResult = XORChiperText(text, key);
            byte[] bytes = Encoding.UTF8.GetBytes(xorResult);
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        public string HexToXORChiperText(string hexText, string key)
        {
            byte[] bytes = new byte[hexText.Length / 2];
            for (int i = 0; i < hexText.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexText.Substring(i, 2), 16);
            }
            string xorResult = Encoding.UTF8.GetString(bytes);
            return XORChiperText(xorResult, key);
        }
    }