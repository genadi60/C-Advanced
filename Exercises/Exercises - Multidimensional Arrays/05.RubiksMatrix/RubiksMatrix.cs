using System;
using System.Linq;

class RubiksMatrix
{
    static void Main()
    {
        var matrixSize = Console.ReadLine()
            .Split(new []{' '},StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var rows = matrixSize[0];
        var cols = matrixSize[1];
        int[,] matrix = new int[rows, cols];
        var value = 0;
        for (int rIndex = 0; rIndex < rows; rIndex++)
        {
            for (int cIndex = 0; cIndex < cols; cIndex++)
            {
                matrix[rIndex, cIndex] = ++value;
            }
        }

        var operationsNumber = int.Parse(Console.ReadLine());
        for (int i = 0; i < operationsNumber; i++)
        {
            var operation = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            var moves = int.Parse(operation[2]);
            var position = int.Parse(operation[0]);
            switch (operation[1])
            {
                case "up":
                    for (int j = 0; j < moves % rows; j++)
                    {
                        var temp = matrix[0, position];
                        for (int k = 0; k < matrix.GetLength(0) - 1; k++)
                        {
                            matrix[k, position] = matrix[k + 1, position];
                        }

                        matrix[rows - 1, position] = temp;
                    }
                    break;
                case "down":
                    for (int j = 0; j < moves % rows; j++)
                    {
                        var temp = matrix[rows - 1, position];
                        for (int k = matrix.GetLength(0) - 1; k > 0 ; k--)
                        {
                            matrix[k, position] = matrix[k - 1, position];
                        }

                        matrix[0, position] = temp;
                    }
                    break;
                case "left":
                    for (int j = 0; j < moves % cols; j++)
                    {
                        var temp = matrix[position, 0];
                        for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                        {
                            matrix[position, k] = matrix[position, k + 1];
                        }

                        matrix[position, cols - 1] = temp;
                    }
                    break;
                case "right":
                    for (int j = 0; j < moves % cols; j++)
                    {
                        var temp = matrix[position, cols - 1];
                        for (int k = matrix.GetLength(1) - 1; k > 0; k--)
                        {
                            matrix[position, k] = matrix[position, k - 1];
                        }

                        matrix[position, 0] = temp;
                    }
                    break;
            }
        }

        value = 0;
        for (int rIndex = 0; rIndex < rows; rIndex++)
        {
            for (int cIndex = 0; cIndex < cols; cIndex++)
            {
                value++;
                if (matrix[rIndex, cIndex] != value)
                {
                    var temp = matrix[rIndex, cIndex];
                    matrix[rIndex, cIndex] = value;
                    var colIndex = cIndex + 1;
                    for (int i = rIndex; i < rows; i++)
                    {
                        for (int j = colIndex; j < cols; j++)
                        {
                            if (matrix[i, j] == value)
                            {
                                matrix[i, j] = temp;
                                Console.WriteLine($"Swap ({rIndex}, {cIndex}) with ({i}, {j})");
                                break;
                            }
                        }
                    colIndex = 0;
                    }
                }
                else
                {
                    Console.WriteLine("No swap required"); 
                }
            }
        }
    }
}