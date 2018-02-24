using System;
using System.Collections.Generic;

class Sneaking
{
    static void Main()
    {
        var matrixSize = int.Parse(Console.ReadLine());
        var room = new char[matrixSize][];
        var playerCoordinates = new List<int>();
        var nikoladzeCoordinates = new List<int>();

        for (int counter = 0; counter < matrixSize; counter++)
        {
            var input = Console.ReadLine().Trim();
            room[counter] = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'S')
                {
                    playerCoordinates.Add(counter);
                    playerCoordinates.Add(i);
                }
                if (input[i] == 'N')
                {
                    nikoladzeCoordinates.Add(counter);
                    nikoladzeCoordinates.Add(i);
                }
            }
        }
        var moves = new Queue<char>(Console.ReadLine().Trim().ToCharArray());
        var result = 0;

        while (moves.Count > 0)
        {
            result = ResolveEnemyMoves(room, playerCoordinates);
            if (result == -1)
            {
                break;
            }

            result = ResolvePlayerMove(room, moves, playerCoordinates, nikoladzeCoordinates);
            if (result == -1 || result == 1)
            {
                break;
            }
        }

        if (result == 1)
        {
            Console.WriteLine("Nikoladze killed!");
            for (int i = 0; i < matrixSize; i++)
            {
                Console.WriteLine(string.Join("", room[i]));
            }
        }

        if (result == -1)
        {
            Console.WriteLine($"Sam died at {playerCoordinates[0]}, {playerCoordinates[1]}");
            for (int i = 0; i < matrixSize; i++)
            {
                Console.WriteLine(string.Join("", room[i]));
            }
        }
    }

    private static int ResolvePlayerMove(char[][] room, Queue<char> moves, List<int> coordinates, List<int> coordinatesEnemy)
    {
        var move = moves.Dequeue();
        var row = coordinates[0];
        var col = coordinates[1];
        var enemyRow = coordinatesEnemy[0];
        var enemyCol = coordinatesEnemy[1];
        
        switch (move)
        {
            case 'U':
                room[row][col] = '.';
                coordinates[0] = row - 1;
                room[row - 1][col] = 'S';
                if (row - 1 == enemyRow)
                {
                    room[enemyRow][enemyCol] = 'X';
                    return 1;
                }
                return 0;

            case 'D':
                room[row][col] = '.';
                coordinates[0] = row + 1;
                room[row + 1][col] = 'S';
                if (row + 1 == enemyRow)
                {
                    room[enemyRow][enemyCol] = 'X';
                    return 1;
                }
                return 0;

            case 'L':
                room[row][col] = '.';
                coordinates[1] = col - 1;
                return 0;

            case 'R':
                room[row][col] = '.';
                coordinates[1] = col + 1;
                return 0;

            default:
                return 0;
        }
    }

    private static int ResolveEnemyMoves(char[][] room, List<int> coordinates)
    {
        var size = room[0].Length;
        var row = coordinates[0];
        var col = coordinates[1];
        var result = 0;
        for (int rIndex = 0; rIndex < room.GetLength(0); rIndex++)
        {
            for (int cIndex = 0; cIndex < size; cIndex++)
            {
                if (room[rIndex][cIndex] == 'b')
                {
                    if (cIndex < size - 1)
                    {
                        if (rIndex == row && col > cIndex)
                        {
                            room[row][col] = 'X';
                            result = -1;
                        }
                        room[rIndex][cIndex] = '.';
                        room[rIndex][cIndex + 1] = 'b';
                    }
                    else
                    {
                        room[rIndex][cIndex] = 'd';
                        if (row == rIndex)
                        {
                            room[row][col] = 'X';
                            result = -1;
                        }
                    }
                    cIndex++;
                }
                else if (room[rIndex][cIndex] == 'd')
                {
                    if (cIndex > 0)
                    {
                        if (rIndex == row && col < cIndex)
                        {
                            room[row][col] = 'X';
                            result = -1;
                        }
                        room[rIndex][cIndex] = '.';
                        room[rIndex][cIndex - 1] = 'd';
                    }
                    else
                    {
                        room[rIndex][cIndex] = 'b';
                        if (rIndex == row)
                        {
                            room[row][col] = 'X';
                            result = -1;
                        }
                    }
                }
            }
        }
        return result;
    }
}