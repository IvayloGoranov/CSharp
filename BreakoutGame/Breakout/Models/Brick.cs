namespace Breakout.Models
{
    using System;
    using Contracts;

    internal class Brick : IBrick
    {
        private char symbol;

        private bool isVisible;

        public Brick(int positionY, int positionX, bool isColored)
        {
            this.isVisible = true;
            this.symbol = '#';

            this.PositionY = positionY;
            this.PositionX = positionX;
            this.IsColored = isColored;
        }

        public int PositionX { get; private set; }

        public int PositionY { get; private set; }

        public bool IsColored { get; private set; }

        public char getSymbol()
        {
            return this.symbol;
        }

        public void setInvisible()
        {
            this.isVisible = false;
            this.symbol = ' ';
        }

        public bool getVisibility()
        {
            return this.isVisible;
        }
    }
}