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
}
