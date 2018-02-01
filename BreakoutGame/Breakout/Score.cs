namespace Breakout
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class Score
    {
        private const int TopGamersRanklistCount = 5;

        private readonly SortedDictionary<int, string> topGamersRanklist;

        private int points;

        public Score(IGamer gamer)
        {
            this.points = 0;
            this.CurrentGamer = gamer;
            this.topGamersRanklist = new SortedDictionary<int, string>();
        }

        public IGamer CurrentGamer { get; private set; }

        public void SaveScore()
        {
            Console.Clear();
            Console.WriteLine("Game Over!"); // The ball did not land on the paddle.
            Console.WriteLine("Your score: {0}", this.points);
            this.CurrentGamer.GamerPoints = this.points;
            Console.Write("Enter you nickname to save the score: ");
            this.CurrentGamer.GamerName = Console.ReadLine();
            Console.Clear();
            this.SaveTopResult();
            this.points = 0;
        }

        public void UpdateCurrentScore()
        {
            this.points++;
        }

        private void SaveTopResult()
        {
            if (this.topGamersRanklist.Count < TopGamersRanklistCount)
            {
                if (!this.topGamersRanklist.ContainsKey(this.CurrentGamer.GamerPoints))
                {
                    this.topGamersRanklist.Add(this.CurrentGamer.GamerPoints, this.CurrentGamer.GamerName);
                }
            }
            else
            {
                var ranklistContainsLowerResult = this.topGamersRanklist.Any(g => g.Key < this.CurrentGamer.GamerPoints);
                var gamerToRemove = this.topGamersRanklist.LastOrDefault(g => g.Key < this.CurrentGamer.GamerPoints);

                if (ranklistContainsLowerResult)
                {
                    this.topGamersRanklist.Remove(gamerToRemove.Key);
                    this.topGamersRanklist.Add(this.CurrentGamer.GamerPoints, this.CurrentGamer.GamerName);
                }
            }
        }

        public void PrintBestScores()
        {
            if (this.topGamersRanklist.Count > 0)
            {
                int i = 0;
                foreach (var topGamer in this.topGamersRanklist.Reverse())
                {
                    Console.SetCursorPosition(13, 16 + i);
                    Console.WriteLine(
                        "{0}. {1} -> {2}", i + 1, topGamer.Value, topGamer.Key);
                    i++;
                }
            }
            else
            {
                Console.SetCursorPosition(35, 16);
                Console.WriteLine("Empty ranklist!");
            }
        }
    }
}
