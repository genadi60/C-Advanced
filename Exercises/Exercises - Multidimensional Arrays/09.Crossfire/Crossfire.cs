using System;
using System.Collections.Generic;
using System.Linq;

class Crossfire
{
    static void Main()
    {
        var matrixSize = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var rows = matrixSize[0];
        var cols = matrixSize[1];
        string[,] matrix = new String[rows, cols];
        for (int rIndex = 0; rIndex < rows; rIndex++)
        {
            for (int cIndex = 0; cIndex < cols; cIndex++)
            {
                matrix[rIndex, cIndex] = (rIndex * cols + cIndex + 1).ToString();
            }
        }

        while (true)
        {
            var input = Console.ReadLine();
            if ("Nuke it from orbit".Equals(input))
            {
                break;
            }
            var shotData = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var shotRow = shotData[0];
            var shotCol = shotData[1];
            var shotRadius = shotData[2];


            for (int rIndex = 0; rIndex < rows; rIndex++)
            {
                for (int cIndex = 0; cIndex < cols; cIndex++)
                {
                    if ((Math.Abs(rIndex - shotRow) <= shotRadius && cIndex == shotCol) ||
                        (Math.Abs(cIndex - shotCol) <= shotRadius && rIndex == shotRow))
                    {
                        matrix[rIndex, cIndex] = " ";
                    }
                }
            }

            var count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == " ")
                    {
                        count++;
                        continue;
                    }

                    if (count > 0)
                    {
                        matrix[i, j - count] = matrix[i, j];
                        matrix[i, j] = " ";
                    }
                }

                count = 0;
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + " ");
            }

            Console.WriteLine();
        }
    }
}
