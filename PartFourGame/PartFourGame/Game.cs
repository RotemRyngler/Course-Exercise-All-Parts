using System;

namespace PartFourGame
{
    public class Game
    {
        public Board BoardGame { get; set; }
        public GameStatus Status { get; set; } 
        public int Points { get; protected set; } 
        public Game()
        {
            BoardGame = new Board();
            Status = GameStatus.Idle;
            Points = 0;
        }
        public void Move(Direction direction)
        {
            if (Status == GameStatus.Idle)
            {
                Points += BoardGame.Move(direction);
                Status = UpdateStatus();
            }
        }
        private GameStatus UpdateStatus()
        {
            for (int i = 0; i < BoardGame.Data.GetLength(0); i++)
            {
                for (int j = 0; j < BoardGame.Data.GetLength(1); j++)
                {
                    if (BoardGame.Data[i, j] == 2048)
                    {
                        return GameStatus.Win;
                    }
                }
            }
            if (PlayerLost() == true)
            {
                return GameStatus.Lose; 
            }
            else
            {
                return GameStatus.Idle; 
            }
        } 
        private bool PlayerLost()
        {
            if (BoardGame.BoardFull())
            {
                int[,] board = BoardGame.Data;
                for(int i=0; i<board.GetLength(0)-1; i++)
                {
                    for (int j=0; j<board.GetLength(1)-1; j++)
                    {
                        if(board[i,j] == board[i, j+1] || board[i,j] == board[i+1, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false; 
        }
    }
}
