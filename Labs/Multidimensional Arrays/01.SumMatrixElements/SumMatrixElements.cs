using System;

class SumMatrixElements
{
    static void Main()
    {
        var matrixSize = Console.ReadLine().Split(new []{',',' '},StringSplitOptions.RemoveEmptyEntries);
        var row = int.Parse(matrixSize[0]);
        var col = int.Parse(matrixSize[1]);
        int[,] matrix = new int[row, col];

        for (int rowIndex = 0; rowIndex < row; rowIndex++)
        {
            var rowElements = Console.ReadLine().Split(new []{',',' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int colIndex = 0; colIndex < col; colIndex++)
            {
                matrix[rowIndex, colIndex] = int.Parse(rowElements[colIndex]);
            }
        }

        var sum = 0;
        foreach (var number in matrix)
        {
            sum += number;
        }

        Console.WriteLine(row);
        Console.WriteLine(col);
        Console.WriteLine(sum);
    }
}