using System;

namespace PartFourGame
{
    public class Board
    {
        public int[,] Data { get; protected set; }
        public Board()
        {
            Data = new int[4, 4];
            Console.WriteLine(Data);
            InitialSet();
        }
        public void InitialSet()
        {
            SetRandoms(2);
        }
        private void SetRandoms(int amount)
        {
            Random random = new Random();
            int row, col;
            for (int i=0; i<amount; i++)
            {
                do
                {
                    row = random.Next(0, Data.GetLength(0));
                    col = random.Next(0, Data.GetLength(1));
                }
                while (Data[row, col] != 0 && BoardFull() == false);
                if (BoardFull() == false)
                {
                    int randomIndex = random.Next(2);
                    int randomValue = (randomIndex == 0) ? 2 : 4;
                    Data[row, col] = randomValue;
                }
            }
        } 
        public bool BoardFull()
        {
            for (int i=0; i < Data.GetLength(0); i++)
            {
                for (int j=0; j<Data.GetLength(1); j++)
                {
                    if(Data[i,j] == 0)
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }
        public int Move(Direction direction)
        {
            int points = DecideDirection(direction);
            SetRandoms(1);
            return points; 
        }
        private int DecideDirection (Direction direction)
        {
            int points = 0;
            if (direction == Direction.Up || direction == Direction.Down)
            {
                for (int i = 0; i < Data.GetLength(1); i++)
                {
                    switch (direction)
                    {
                        case Direction.Up:
                            points += CombineCubesUp(i);
                            break;
                        case Direction.Down:
                            points += CombineCubesDown(i);
                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < Data.GetLength(0); i++)
                {
                    switch (direction)
                    {
                        case Direction.Left:
                            points += CombineCubesLeft(i);
                            break;
                        case Direction.Right:
                            points += CombineCubesRight(i);
                            break;
                    }
                }
            }
            return points;
        }
        private int CombineCubesUp(int column)
        {
            int sumIndex = 0;
            int points = 0; 
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                if (Data[i, column] != 0)
                {
                    int j = i + 1;
                    while (j < Data.GetLength(0) && Data[j, column] == 0)
                    {
                        j++;
                    }
                    if (j < Data.GetLength(0) && Data[i, column] == Data[j, column])
                    {
                        Data[sumIndex, column] = Data[i, column] * 2;
                        points += Data[sumIndex, column];
                        Data[j, column] = 0;
                    }
                    else
                    {
                        Data[sumIndex, column] = Data[i, column];
                    }
                    sumIndex++;
                }
            }
            for (int i = sumIndex; i < Data.GetLength(0); i++)
            {
                Data[i, column] = 0;
            }
            return points; 
        }
        private int CombineCubesLeft(int row)
        {
            int sumIndex = 0;
            int points = 0; 
            for (int i = 0; i < Data.GetLength(1); i++)
            {
                if (Data[row, i] != 0)
                {
                    int j = i + 1;
                    while (j < Data.GetLength(1) && Data[row, j] == 0)
                    {
                        j++;
                    }
                    if (j < Data.GetLength(1) && Data[row, i] == Data[row, j])
                    {
                        Data[row, sumIndex] = Data[row, i] * 2;
                        points += Data[row, sumIndex]; 
                        Data[row, j] = 0;
                    }
                    else
                    {
                        Data[row, sumIndex] = Data[row, i];
                    }
                    sumIndex++;
                }
            }
            for (int i = sumIndex; i < Data.GetLength(1); i++)
            {
                Data[row, i] = 0;
            }
            return points; 
        }
        private int CombineCubesRight(int row)
        {
            int sumIndex = Data.GetLength(1) - 1;
            int points = 0; 
            for (int i = Data.GetLength(1) - 1; i >= 0; i--)
            {
                if (Data[row, i] != 0)
                {
                    int j = i - 1;
                    while (j >= 0 && Data[row, j] == 0)
                    {
                        j--;
                    }
                    if (j >= 0 && Data[row, i] == Data[row, j])
                    {
                        Data[row, sumIndex] = Data[row, i] * 2;
                        points += Data[row, sumIndex]; 
                        Data[row,j] = 0;
                    }
                    else
                    {
                        Data[row, sumIndex] = Data[row, i];
                    }
                    sumIndex--;
                }
            }
            for (int i = sumIndex; i >= 0; i--)
            {
                Data[row, i] = 0;
            }
            return points; 
        }
        private int CombineCubesDown(int column)
        {
            int sumIndex = Data.GetLength(0) - 1;
            int points = 0; 
            for (int i = Data.GetLength(0) - 1; i >= 0; i--)
            {
                if (Data[i, column] != 0)
                {
                    int j = i - 1;
                    while (j >= 0 && Data[j, column] == 0)
                    {
                        j--;
                    }
                    if (j >= 0 && Data[i, column] == Data[j, column])
                    {
                        Data[sumIndex, column] = Data[i, column] * 2;
                        points += Data[sumIndex, column]; 
                        Data[j, column] = 0;
                    }
                    else
                    {
                        Data[sumIndex, column] = Data[i, column];
                    }
                    sumIndex--;
                }
            }
            for (int i = sumIndex; i >= 0; i--)
            {
                Data[i, column] = 0;
            }
            return points; 
        }
    }
}
