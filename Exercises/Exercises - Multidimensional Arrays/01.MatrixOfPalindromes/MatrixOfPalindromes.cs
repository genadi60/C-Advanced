using System;
using System.Linq;

class MatrixOfPalindromes
{
    static void Main()
    {
        var matrixSizes = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        string[,] matrix = new string[matrixSizes[0], matrixSizes[1]];
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        for (int rIndex = 0; rIndex < matrix.GetLength(0); rIndex++)
        {
            for (int cIndex = 0; cIndex < matrix.GetLength(1); cIndex++)
            {
                var palindrom = alphabet[rIndex].ToString() + alphabet[rIndex + cIndex] + alphabet[rIndex];
                matrix[rIndex, cIndex] = palindrom;
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}