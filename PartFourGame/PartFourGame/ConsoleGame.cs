using System;

namespace PartFourGame
{
    public class ConsoleGame
    {
        private Game game;
        public ConsoleGame()
        {
            game = new Game(); 
        }
        public void StartGame()
        {
            Console.WriteLine("Welcome to the 2048 game!");
            Console.WriteLine("Use the arrows to move the number cubes. To leave the game click ENTER");
            PrintBoardGame();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    game.Move(Direction.Up);
                    PrintBoardGame();
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    game.Move(Direction.Down);
                    PrintBoardGame();
                }
                else if(keyPressed == ConsoleKey.LeftArrow)
                {
                    game.Move(Direction.Left);
                    PrintBoardGame();
                }
                else if(keyPressed == ConsoleKey.RightArrow)
                {
                    game.Move(Direction.Right);
                    PrintBoardGame();
                }
                else if(keyPressed == ConsoleKey.Enter)
                {
                    Console.WriteLine("You have exited the game... Your score: " + game.Points);
                    break;
                } 
                else
                {
                    Console.WriteLine();
                }
                if(game.Status == GameStatus.Win)
                {
                    Console.WriteLine("Congratulations you have won! Your score: " +game.Points);
                    break;
                }
                else if(game.Status == GameStatus.Lose)
                {
                    Console.WriteLine("Oh no, you have lost. Your score: " +game.Points);
                    break;
                }
            }
        }
        private void PrintBoardGame()
        {
            int[,] board = game.BoardGame.Data; 
            for(int i=0; i<board.GetLength(0); i++)
            {
                for(int j=0; j<board.GetLength(1); j++)
                {
                    Console.Write(board[i,j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------");
        }

    }
}
