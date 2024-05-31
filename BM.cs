namespace Tubes3_let_me_seedik;

using System;

public class BM
{

	public static int[] ListLastOccurance(string pattern)
	{
		int[] listLO = new int[256];
        for (int i = 0; i < listLO.Length; i++)
        {
			listLO[i] = -1;
        }
		for (int i = 0; i < pattern.Length; i++)
		{
			listLO[(int) pattern[i]] = i;
		}
		return listLO;
    }

	public static int BmMatch(string text, string pattern)
	{
		int[] listLO = ListLastOccurance(pattern);
		int lenText = text.Length;
		int lenPattern = pattern.Length;
		int i = lenPattern - 1;
        if (i > lenText - 1)
        {
            return -1;
        }
		int j = lenPattern - 1;
		while(i < lenText - 1)
		{
			if (pattern[j] == text[i])
			{
				if (j == 0)
				{
					return i;
				} else
				{
					i--;
					j--;
				}
			}
            else
            {
				int lastOccurance = listLO[(int)text[i]];
				i = i + lenPattern;
                if (j > 1+lastOccurance)
                {
					i = i - lastOccurance - 1;
                }
                else
                {
					i = i - j;
                }
                j = lenPattern - 1;
            }
        }
		Console.WriteLine("Gagal");
		return -1;
    }
}
