namespace Tubes3_let_me_seedik;

using System;
using System.Linq;

public class Levenshtein
{

	public static void cetakTes()
	{
		Console.WriteLine("Pattern found in text: ");
	}

	public static int LevenshteinDistance(string text, string pattern)
	{
		int nbaris = text.Length + 1;
		int nkolom = pattern.Length + 1;
		int[,] matriks = new int[nbaris,nkolom];

        for (int i = 0; i < nbaris; i++)
        {
			matriks[i,0] = i;
        }

		for (int j = 0; j < nkolom; j++)
		{
			matriks[0,j] = j;
		}
		int biaya = 0;
		for (int i = 1; i <	nbaris; i++)
		{
			for (int j = 1; j < nkolom; j++)
			{
				if (pattern[j-1] == text[i - 1])
				{
					biaya = 0;
				} 
				else
				{
					biaya = 1;
				}
				matriks[i,j] = Math.Min(matriks[i-1,j]+1 , Math.Min(matriks[i,j-1] + 1 , matriks[i-1,j-1] + biaya));
			}
		}

		return matriks[nbaris-1,nkolom-1];
	}

	public static float PersentaseKemiripan(int distance, string text, string pattern)
	{
		return 100-((float)distance *100/Math.Max(pattern.Length, text.Length));
	}

}
