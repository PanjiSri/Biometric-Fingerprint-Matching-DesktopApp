namespace Tubes3_let_me_seedik;

using System;
using System.Drawing;
using System.Text;

public class GrayscaleToASCIIConverter
{
    public string ConvertToASCII(string imagePath)
    {
        Bitmap bitmap = new Bitmap(imagePath);

        StringBuilder asciiImage = new StringBuilder();

        for (int y = 0; y < bitmap.Height; y++)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                Color pixelColor = bitmap.GetPixel(x, y);

                int grayscaleValue = pixelColor.R; 

                char asciiChar = (char)grayscaleValue;

                asciiImage.Append(asciiChar);
            }
        }

        return asciiImage.ToString();
    }

    public string GetBestSegment(string imagePath)
    {
        string asciiImage = ConvertToASCII(imagePath);

        //panjang ASCII gambar < 30
        if (asciiImage.Length < 30)
        {
            return asciiImage;
        }

        int middleIndex = asciiImage.Length / 2;

        int startIndex = middleIndex - 15;

        if (startIndex < 0)
        {
            startIndex = 0;
        }

        int countSegment = 30;
        //ini gak begitu ngaruh sih
        if (startIndex + 30 > asciiImage.Length)
        {
            countSegment = asciiImage.Length - startIndex;
        }

        string bestSegment = asciiImage.Substring(startIndex, countSegment);

        return bestSegment;
    }
}