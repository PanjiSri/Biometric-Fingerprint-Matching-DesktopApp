using Microsoft.SqlServer.Server;
using System;

public class Regex
{
    public bool isMatch(string text, string pattern)
    {
        return isMatchHelper(text, 0, "", pattern, 0);
    }

    private bool isMatchHelper(string text, int text_idx, string prefix, string pattern, int pattern_idx)
    {
        if (pattern_idx == pattern.Length)
        {
            return text_idx == text.Length;
        }

        bool firstMatch = (text_idx < text.Length && (pattern[pattern_idx] == text[text_idx] || pattern[pattern_idx] == '.'));

        if (pattern[pattern_idx] == '(' )
        {
            pattern_idx++;
            String sub = "";
            while (pattern[pattern_idx] != ')' && pattern_idx < pattern.Length)
            {
                sub += pattern_idx;
                pattern_idx++;
            }
        } 
        else if (pattern[pattern_idx] == '[' )
        {
            pattern_idx++;
            String sub = "";
            while (pattern[pattern_idx] != ']' && pattern_idx < pattern.Length)
            {
                sub += pattern_idx;
                pattern_idx++;
            }
        }

        return true;
    }

    private bool checkAllSub(string text, string pattern)
    {
        return true;
    }
}