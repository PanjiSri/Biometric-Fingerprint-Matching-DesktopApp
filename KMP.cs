namespace Tubes3_let_me_seedik;

using System;

public class KMP
{

	public static void cetakTes()
	{
		Console.WriteLine("Pattern found in text: ");
	}

	public static int[] ComputeBorder(string pattern)
	{
		int m = pattern.Length;
		int[] b = new int[m];
		int j = 0;
		int i = 1;

		b[0] = 0;

		while (i < m)
		{
			if (pattern[j] == pattern[i])
			{
				j++;
				b[i] = j;
				i++;
			}
			else if (j > 0)
				j = b[j - 1];
			else
			{
				b[i] = 0;
				i++;
			}
		}
		
		return b;
	}

	public static int KmpMatch(string text, string pattern)
	{
		int n = text.Length;
		int m = pattern.Length;
		int[] b = ComputeBorder(pattern);
		int i = 0;
		int j = 0;

		while (i < n)
		{
			if (pattern[j] == text[i])
			{
				if (j == m - 1)
					return i - m + 1; // Ketemu
				i++;
				j++;
			}
			else if (j > 0)
				j = b[j - 1];
			else
				i++;
		}

		return -1; // Gak Ketemu
	}
}
