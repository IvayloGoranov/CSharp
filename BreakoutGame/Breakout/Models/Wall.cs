namespace Breakout.Models
{
    using System;
    using Contracts;

    internal class Wall : IWall
    {
        public Wall(int height, int width, IFillingPattern pattern)
        {
            this.Height = height;
            this.Width = width;
            this.FilledWall = new IBrick[height, width];
            this.FillingPattern = pattern;
        }

        public int Height { get; private set; }

        public int Width { get; private set; }

        public IBrick[,] FilledWall { get; private set; }

        public IFillingPattern FillingPattern { get; private set; }

        public void DrawWall()
        {
            FillingPattern.FillWall(this);
            Console.SetCursorPosition(0, 1);

            for (int i = 0; i < this.FilledWall.GetLength(0); i++)
            {
                for (int j = 0; j < this.FilledWall.GetLength(1); j++)
                {
                    if (this.FilledWall[i, j].IsColored)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(this.FilledWall[i, j].getSymbol());
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(this.FilledWall[i, j].getSymbol());
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void UpdateWall(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
    }
}
