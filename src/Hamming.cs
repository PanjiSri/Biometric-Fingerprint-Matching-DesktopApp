namespace Tubes3_let_me_seedik;

using System;
using System.Linq;

public class Hamming
{

	public static void cetakTes()
	{
		Console.WriteLine("Pattern found in text: ");
	}

	public static int HammingDistance(string text, string pattern)
	{
		int i = 0, count = 0; 
		while (i < pattern.Length) 
		{ 
			if (text[i] != pattern[i]) 
				count++; 
			i++; 
		} 
		return count; 
	}

	public static float PersentaseKemiripan(int distance, string text, string pattern)
	{
		return 100-((float)distance *100/Math.Max(pattern.Length, text.Length));
	}

}
