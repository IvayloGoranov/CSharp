namespace Breakout
{
    using System;

    using Breakout.Contracts;

    public class Gamer : IGamer
    {
        private string gamerName;

        private bool gamerStartsTheGame = true;

        private bool gamerEndsTheGameSuccessfully = false;
        private int gamerPoints;

        public Gamer()
        {
            this.GamerStartsTheGame = this.gamerStartsTheGame;
            this.GamerEndsTheGameSuccessfully = this.gamerEndsTheGameSuccessfully;
        }

        public Gamer(string gamerName, int gamerPoints)
        {
            this.GamerName = gamerName;
            this.GamerPoints = gamerPoints;
        }

        public string GamerName
        {
            get
            {
                return this.gamerName;
            }

            set 
            {
                ValidateGamerName(value);

                this.gamerName = value;
            }
        }

        public int GamerPoints
        {
            get 
            {
                return this.gamerPoints;
            }

            set 
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.gamerPoints = value;
            }
        }

        public bool GamerStartsTheGame { get; private set; }

        public bool GamerEndsTheGameSuccessfully { get; private set; }

        private static void ValidateGamerName(string value)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.Write("Please enter correct name: ");
                    continue;
                }
                
                break;
            }
        }
    }
}
