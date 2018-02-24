using System;

class KnightGame
{
    static void Main()
    {
        var size = int.Parse(Console.ReadLine());
        var matrix = new char[size][];
        for (int count = 0; count < size; count++)
        {
            matrix[count] = Console.ReadLine().ToCharArray();
        }

        var maxStrikeRow = 0;
        var maxStrikeCol = 0;
        var maxSrikes = 0;
        var removedKnightsCounter = 0;

        while (true)
        {
            for (int rIndex = 0; rIndex < size; rIndex++)
            {
                for (int cIndex = 0; cIndex < size; cIndex++)
                {
                    if (matrix[rIndex][cIndex] == 'K')
                    {
                        var calculatedSrikes = CalculateStrikes(size, rIndex, cIndex, matrix);
                        if (maxSrikes < calculatedSrikes)
                        {
                            maxSrikes = calculatedSrikes;
                            maxStrikeRow = rIndex;
                            maxStrikeCol = cIndex;
                        }
                    }
                }
            }

            if (maxSrikes > 0)
            {
                matrix[maxStrikeRow][maxStrikeCol] = 'O';
                maxSrikes = 0;
                removedKnightsCounter++;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(removedKnightsCounter);
    }

    private static int CalculateStrikes(int size, int rindex, int cindex, char[][] matrix)
    {
        var strikeCounter = 0;

        if (rindex < size - 1 && cindex >= 2 )
        {
            if (matrix[rindex + 1][cindex - 2] == 'K')
            {
                strikeCounter++;
            }
        }
        
        if (rindex < size - 1 && cindex < size - 2)
        {
            if (matrix[rindex + 1][cindex + 2] == 'K')
            {
                strikeCounter++;
            }
        }

        if (rindex >= 1 && cindex < size - 2)
        {
            if (matrix[rindex - 1][cindex + 2] == 'K')
            {
                strikeCounter++;
            }
        }

        if (rindex >= 1 && cindex >= 2)
        {
            if (matrix[rindex - 1][cindex - 2] == 'K')
            {
                strikeCounter++;
            }
        }

        if (rindex < size - 2 && cindex >= 1)
        {
            if (matrix[rindex + 2][cindex - 1] == 'K')
            {
                strikeCounter++;
            }
        }

        if (rindex < size - 2 && cindex < size - 1)
        {
            if (matrix[rindex + 2][cindex + 1] == 'K')
            {
                strikeCounter++;
            }
        }

        if (rindex >= 2 && cindex < size - 1)
        {
            if (matrix[rindex - 2][cindex + 1] == 'K')
            {
                strikeCounter++;
            }
        }

        if (rindex >= 2 && cindex >= 1)
        {
            if (matrix[rindex - 2][cindex - 1] == 'K')
            {
                strikeCounter++;
            }
        }

        return strikeCounter;
    }
}