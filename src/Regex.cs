namespace Tubes3_let_me_seedik;

using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;
using System;
using System.Text;

public class Regexp
{
    public bool isMatch(string text, string pattern)
    {
        Match match = Regex.Match(text, pattern);
        return match.Success;
    }

    public string createRegex(string text)
    {
        StringBuilder pattern = new StringBuilder();
        foreach (char c in text)
        {
            pattern.Append(charToPattern(c));
        }
        return pattern.ToString();
    }

    private string charToPattern(char c)
    {
        switch (char.ToLower(c))
        {
            case 'a':
                return "[aA4]?";
            case 'b':
                return "[bB8]";
            case 'c':
                return "[cC]";
            case 'd':
                return "[dD]";
            case 'e':
                return "[eE3]?";
            case 'f':
                return "[fF]";
            case 'g':
                return "[gG69]";
            case 'h':
                return "[hH]";
            case 'i':
                return "[iI1]?";
            case 'j':
                return "[jJ]";
            case 'k':
                return "[kK]";
            case 'l':
                return "[lL]";
            case 'm':
                return "[mM]";
            case 'n':
                return "[nN]";
            case 'o':
                return "[oO0]?";
            case 'p':
                return "[pP]";
            case 'q':
                return "[qQ]";
            case 'r':
                return "[rR]";
            case 's':
                return "[sS5]";
            case 't':
                return "[tT7]";
            case 'u':
                return "[uU]?";
            case 'v':
                return "[vV]";
            case 'w':
                return "[wW]";
            case 'x':
                return "[xX]";
            case 'y':
                return "[yY]";
            case 'z':
                return "[zZ2]";
            case ' ':
                return "\\s+";
        }
        return c.ToString();
    }
}