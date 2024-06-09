namespace Tubes3_let_me_seedik;

using System;
using System.Text;

public class CaesarCipher{
    
    private const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public string Encrypt(string text, int shift)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
                char currentChar = text[i];
                if (allowedChars.Contains(currentChar))
                {
                    int index = allowedChars.IndexOf(currentChar);
                    int newIndex = (index + shift) % allowedChars.Length;
                    result.Append(allowedChars[newIndex]);
                }
                else
                {
                    result.Append(currentChar);
                }
        }

        return result.ToString();
    }

    public string Decrypt(string text, int shift)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char currentChar = text[i];
            if (allowedChars.Contains(currentChar))
            {
                    int index = allowedChars.IndexOf(currentChar);
                    int newIndex = (index - shift + allowedChars.Length) % allowedChars.Length;
                    result.Append(allowedChars[newIndex]);
            }
            else
            {
                    result.Append(currentChar);
            }
        }

        return result.ToString();
    }
}