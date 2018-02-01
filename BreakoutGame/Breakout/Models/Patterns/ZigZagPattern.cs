namespace Breakout.Models.Patterns
{
    using System;
    using Contracts;

    class ZigZagPattern : IFillingPattern
    {
        public void FillWall(IWall wall)
        {
            Console.SetCursorPosition(0, 1);
            int counter = 0;

            for (int row = 0; row < wall.Height; row++)
            {
                for (int column = 0; column < wall.Width; column++)
                {
                   if (column <= 1 || column >= wall.Width - 2 || row == 0 || row == wall.Height - 1)
                    {
                        wall.FilledWall[row, column] = new Brick(row, column, false);
                    }
                    else
                    {
                        wall.FilledWall[row, column] = new Brick(row, column, true);
                    }

                    if (counter % 2 == 0 
                        || (row == wall.Height - 1 && column == 0)
                        || (row == wall.Height - 1 && column == wall.Width - 1))
                    {
                        wall.FilledWall[row, column].setInvisible();
                    }

                    counter++;
                }
            }
        }
    }
}
