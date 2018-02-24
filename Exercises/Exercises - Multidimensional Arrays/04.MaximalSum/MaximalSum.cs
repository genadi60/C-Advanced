using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        var matrixSize = Console.ReadLine()
            .Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var rows = matrixSize[0];
        var cols = matrixSize[1];
        double[,] matrix = new Double[rows, cols];

        for (int rIndex = 0; rIndex < rows; rIndex++)
        {
            var row = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            for (int cIndex = 0; cIndex < cols; cIndex++)
            {
                matrix[rIndex, cIndex] = row[cIndex];
            }
        }

        var sum = 0.0;
        var maxSum = double.MinValue;
        var indexRow = -1;
        var indexCol = -1;
        for (int i = 0; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                sum = 0.0;
                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        sum += matrix[i + k, j + l];
                    }
                }

                if (maxSum < sum)
                {
                    maxSum = sum;
                    indexRow = i;
                    indexCol = j;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[indexRow + i, indexCol + j] + " ");
            }
            Console.WriteLine();
        }
    }
}