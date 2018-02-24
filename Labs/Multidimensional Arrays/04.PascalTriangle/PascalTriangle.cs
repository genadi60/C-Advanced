using System;

class PascalTriangle
{
    static void Main()
    {
        var height = int.Parse(Console.ReadLine());
        long[][] pascalTriangle = new long[height][];
        for (int i = 0; i < pascalTriangle.Length; i++)
        {
            var row = i;
            pascalTriangle[row] = new long[row + 1];
            pascalTriangle[row][0] = 1;
            pascalTriangle[row][row] = 1;
            if (row >= 2)
            {
                for (int j = 1; j < row; j++)
                {
                    pascalTriangle[row][j] = pascalTriangle[row - 1][j - 1] +
                                             pascalTriangle[row - 1][j];
                } 
            }
        }

        for (int rIndex = 0; rIndex < pascalTriangle.Length; rIndex++)
        {
            for (int cIndex = 0; cIndex < pascalTriangle[rIndex].Length; cIndex++)
            {
                Console.Write(pascalTriangle[rIndex][cIndex] + " ");
            }

            Console.WriteLine();
        }
    }
}