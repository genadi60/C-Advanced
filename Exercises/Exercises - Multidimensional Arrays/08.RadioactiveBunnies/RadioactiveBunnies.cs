using System;
using System.Linq;

class RadioactiveBunnies
{
    private static int BunniAction(char[,] matrix, int playerRow, int playerCol)
    {
        var rowSize = matrix.GetLength(0);
        var colSize = matrix.GetLength(1);
        var result = 0;
        for (int rIndex = 0; rIndex < rowSize; rIndex++)
        {
            for (int cIndex = 0; cIndex < colSize; cIndex++)
            {

                if (matrix[rIndex, cIndex] == 'B')
                {
                    if ((Math.Max(0, rIndex - 1) == playerRow && cIndex == playerCol) || 
                        (Math.Min(rowSize - 1, rIndex + 1) == playerRow && cIndex == playerCol) ||
                        (rIndex == playerRow && Math.Max(0, cIndex - 1) == playerCol) ||
                        (rIndex == playerRow && Math.Min(colSize - 1, cIndex + 1) == playerCol))
                    {
                        result = -1;
                    }
                    
                    matrix[Math.Max(0, rIndex - 1), cIndex] = 'B';
                    if (matrix[Math.Min(rowSize - 1, rIndex + 1), cIndex] != 'B')
                    {
                        matrix[Math.Min(rowSize - 1, rIndex + 1), cIndex] = 'C';
                    }
                    matrix[rIndex, Math.Max(0, cIndex - 1)] = 'B';
                    if (matrix[rIndex, Math.Min(colSize - 1, cIndex + 1)] != 'B')
                    {
                        matrix[rIndex, Math.Min(colSize - 1, cIndex + 1)] = 'C';
                    }
                    
                } 
            }
        }

        for (int rIndex = 0; rIndex < rowSize; rIndex++)
        {
            for (int cIndex = 0; cIndex < colSize; cIndex++)
            {
                if (matrix[rIndex, cIndex] == 'C')
                {
                    matrix[rIndex, cIndex] = 'B';
                }
            }
        }
        return result;
    }
    static void Main()
    {
        var matrixSizes = Console.ReadLine()
            .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var rows = matrixSizes[0];
        var cols = matrixSizes[1];
        char[,] matrix = new char[rows, cols];
        var playerRow = -1;
        var playerCol = -1;
        for (int rIndex = 0; rIndex < rows; rIndex++)
        {
            var elements = Console.ReadLine().ToCharArray();
            for (int cIndex = 0; cIndex < cols; cIndex++)
            {
                matrix[rIndex, cIndex] = elements[cIndex];
                if (elements[cIndex].Equals('P'))
                {
                    playerRow = rIndex;
                    playerCol = cIndex;
                }
            }
        }
        var commands = Console.ReadLine().ToCharArray();
        var result = 0;
        for (int index = 0; index < commands.Length; index++)
        {
            var previosRow = 0;
            var previosCol = 0;
            var command = commands[index];
            switch (command)
            {
                case 'R':
                    previosRow = playerRow;
                    previosCol = playerCol++;
                    matrix[previosRow, previosCol] = '.';
                    result = PlayerAction(matrix, playerRow, playerCol);
                    break;
                case 'L':
                    previosRow = playerRow;
                    previosCol = playerCol--;
                    matrix[previosRow, previosCol] = '.';
                    result = PlayerAction(matrix, playerRow, playerCol);
                    break;
                case 'U':
                    previosRow = playerRow--;
                    previosCol = playerCol;
                    matrix[previosRow, previosCol] = '.';
                    result = PlayerAction(matrix, playerRow, playerCol);
                    break;
                case 'D':
                    previosRow = playerRow++;
                    previosCol = playerCol;
                    matrix[previosRow, previosCol] = '.';
                    result = PlayerAction(matrix, playerRow, playerCol);
                    break;
            }

            switch (result)
            {
                case 0:
                    break;
                case 1:
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {previosRow} {previosCol}");
                    return;
                case -1:
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
            }
        }
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int rIndex = 0; rIndex < matrix.GetLength(0); rIndex++)
        {
            for (int cIndex = 0; cIndex < matrix.GetLength(1); cIndex++)
            {
                Console.Write(matrix[rIndex, cIndex]);
            }
            Console.WriteLine();
        }
    }

    private static int PlayerAction(char[,] matrix, int playerRow, int playerCol)
    {
        if (playerRow >= matrix.GetLength(0) || playerRow < 0 || playerCol >= matrix.GetLength(1) || playerCol < 0)
        {
            BunniAction(matrix, playerRow, playerCol);
            return 1;
        }
        if (matrix[playerRow, playerCol].Equals('.'))
        {
            matrix[playerRow, playerCol] = 'P';
            return BunniAction(matrix, playerRow, playerCol);
        }
        BunniAction(matrix, playerRow, playerCol);
        return -1;
    }
}