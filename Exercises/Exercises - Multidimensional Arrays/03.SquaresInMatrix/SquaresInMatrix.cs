using System;
using System.Linq;

class SquaresInMatrix
{
    static void Main()
    {
        var matrixSize = Console.ReadLine()
            .Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var rows = matrixSize[0];
        var cols = matrixSize[1];
        string[,] matrix = new string[rows,cols];

        for (int rIndex = 0; rIndex < rows; rIndex++)
        {
            var row = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int cIndex = 0; cIndex < cols; cIndex++)
            {
                matrix[rIndex, cIndex] = row[cIndex];
            }
        }

        var count = 0;
        bool isEqual = true;
        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                var temp = matrix[i, j];
                for (int k = 0; k < 2; k++)
                {
                    for (int l = 0; l < 2; l++)
                    {
                        if (!temp.Equals(matrix[i + k, j + l]))
                        {
                            isEqual = false;
                        }
                    }
                }

                if (isEqual)
                {
                    count++;
                }
                else
                {
                    isEqual = true;
                }
            }
        }

        Console.WriteLine(count);
    }
}