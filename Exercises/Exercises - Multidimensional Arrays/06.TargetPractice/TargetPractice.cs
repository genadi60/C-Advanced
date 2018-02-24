using System;
using System.Collections.Generic;
using System.Linq;

class TargetPractice
{
    static void Main()
    {
        var matrixSize = Console.ReadLine()
            .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var rows = matrixSize[0];
        var cols = matrixSize[1];
        char[,] matrix = new Char[rows, cols];
        var message = new Queue<char>(Console.ReadLine().ToCharArray());
        var shotData = Console.ReadLine()
            .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var shotRow = shotData[0];
        var shotCol = shotData[1];
        var shotRadius = shotData[2];
        bool next = true;
        for (int i = rows - 1; i >= 0; i--)
        {
            if (next)
            {
                for (int j = cols - 1; j >= 0; j--)
                {
                    matrix[i, j] = message.Peek();
                    message.Enqueue(message.Dequeue());
                }

                next = false;
            }
            else
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = message.Peek();
                    message.Enqueue(message.Dequeue());
                }

                next = true;
            }
        }

        for (int rIndex = 0; rIndex < rows; rIndex++)
        {
            for (int cIndex = 0; cIndex < cols; cIndex++)
            {
                if ((Math.Pow(rIndex - shotRow, 2) + Math.Pow(cIndex - shotCol, 2)) <= Math.Pow(shotRadius, 2))
                {
                    if (rIndex > 0)
                    {
                        for (int i = rIndex; i > 0; i--)
                        {
                            matrix[i, cIndex] = matrix[i - 1, cIndex];
                            matrix[i - 1, cIndex] = ' ';
                        }
                    }
                    else
                    {
                        matrix[rIndex, cIndex] = ' ';
                    }
                }
            }
        }

        for (int rIndex = 0; rIndex < rows; rIndex++)
        {
            for (int cIndex = 0; cIndex < cols; cIndex++)
            {
                if (matrix[rIndex, cIndex] != ' ')
                {
                    Console.Write(matrix[rIndex, cIndex]);
                }
                else
                {
                    Console.Write(' ');
                }
            }

            Console.WriteLine();
        }
    }
}