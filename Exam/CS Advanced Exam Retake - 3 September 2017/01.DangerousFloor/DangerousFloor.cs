using System;
using System.Linq;

class DangerousFloor
{
    static void Main()
    {
        var boardSize = 8;
        char[][] board = new char[boardSize][];
        for (int index = 0; index < boardSize; index++)
        {
            board[index] = Console.ReadLine().Replace(",", "").ToCharArray();
        }

        while (true)
        {
            var input = Console.ReadLine();
            if ("END".Equals(input))
            {
                break;
            }
            var moveData = input.Split(new[] {"-"}, StringSplitOptions.None).ToArray();
            var symbol = moveData[0][0];
            var currentRow = int.Parse(moveData[0].Substring(1, 1));
            var currentCol = int.Parse(moveData[0].Substring(2, 1));
            var newRow = int.Parse(moveData[1].Substring(0, 1));
            var newCol = int.Parse(moveData[1].Substring(1, 1));
            if (CheckPosition(symbol, currentRow, currentCol, board) == false)
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            if (currentRow == newRow && currentCol == newCol)
            {
                continue;
            }
            switch (CheckMove(symbol, currentRow, currentCol, board, newRow, newCol, boardSize))
            {
                case 1:
                    Console.WriteLine("Invalid move!");
                    break;
                case -1:
                    Console.WriteLine("Move go out of board!");
                    break;
                case 0:
                    board[currentRow][currentCol] = 'x'; 
                    board[newRow][newCol] = symbol;
                    break;
            }
        }
    }

    private static int CheckMove(char symbol, int currentRow, int currentCol, char[][] board, int newRow, int newCol, int boardSize)
    {
        if (newRow < 0 || newRow >= boardSize || newCol < 0 || newCol >= boardSize)
        {
            return -1;
        }
        
        var move = "";
        if (currentRow == newRow && currentCol != newCol)
        {
            move = "H";
        }

        else if (currentRow != newRow && currentCol == newCol)
        {
            move = "V";
        }

        else if (Math.Abs(currentRow - newRow) == Math.Abs(currentCol - newCol))
        {
            move = "D";
        }
        else
        {
            return 1;
        }

        switch (symbol)
        {
            case 'K':
                if (Math.Abs(currentRow - newRow) <= 1 && Math.Abs(currentCol - newCol) <= 1)
                {
                    return 0;
                }

                return 1;

            case 'B':
                if (move.Equals("D"))
                {
                    return 0;
                }

                return 1;

            case 'R':
                if (move.Equals("H") || move.Equals("V"))
                {
                    return 0;
                }

                return 1;
                    
            case 'Q':
                return 0;
                    
            case 'P':
                if (move.Equals("V"))
                {
                    if (currentRow - newRow == 1 && currentCol == newCol)
                    {
                        return 0;
                    }
                }
                return 1;
        }
        return 0;
    }
    
    private static bool CheckPosition(char symbol, int currentRow, int currentCol, char[][] board)
    {
        if (symbol == (board[currentRow][currentCol]))
        {
            return true;
        }

        return false;
    }
}