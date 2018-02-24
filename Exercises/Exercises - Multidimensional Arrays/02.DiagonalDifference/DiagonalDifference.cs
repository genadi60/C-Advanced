using System;
using System.Linq;

class DiagonalDifference
{
    static void Main()
    {
        int matrixSize = int.Parse(Console.ReadLine());
        double[,] matrix = new double[matrixSize, matrixSize];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var rowValues = Console.ReadLine()
                .Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                matrix[row, column] = rowValues[column];
            }
        }

        var primaryDiagonalSum = 0.0;
        var secondaryDiagonalSum = 0.0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            primaryDiagonalSum += matrix[row, row];
            secondaryDiagonalSum += matrix[row, matrix.GetLength(1) - 1 - row];
        }

        var difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

        Console.WriteLine(difference);
    }
}