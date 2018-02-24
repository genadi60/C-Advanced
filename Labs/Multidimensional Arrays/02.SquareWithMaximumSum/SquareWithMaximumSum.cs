using System;

class SquareWithMaximumSum
{
    static void Main()
    {
        var matrixSize = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var row = int.Parse(matrixSize[0]);
        var col = int.Parse(matrixSize[1]);
        int[,] matrix = new int[row, col];

        for (int rowIndex = 0; rowIndex < row; rowIndex++)
        {
            var rowElements = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int colIndex = 0; colIndex < col; colIndex++)
            {
                matrix[rowIndex, colIndex] = int.Parse(rowElements[colIndex]);
            }
        }

        var maxSum = int.MinValue;
        var sum = 0;
        var indexes = new int[2];
        for (int rIndex = 0; rIndex < row - 1; rIndex++)
        {
            for (int cIndex = 0; cIndex < col - 1; cIndex++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        sum += matrix[rIndex + i, cIndex + j];
                    }
                }

                if (maxSum < sum)
                {
                    maxSum = sum;
                    indexes[0] = rIndex;
                    indexes[1] = cIndex;
                }

                sum = 0;
            }
        }

        for (int i = indexes[0]; i <= indexes[0] + 1; i++)
        {
            for (int j = indexes[1]; j <= indexes[1] + 1; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine(maxSum);
    }
}