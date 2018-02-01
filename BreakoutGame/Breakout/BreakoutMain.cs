namespace Breakout
{
    using Contracts;

    public class BreakoutMain
    {
        public static void Main()
        {
            IGamer currentGamer = new Gamer();
            Score score = new Score(currentGamer);
            Engine engine = new Engine(score);

            engine.Run();
        }
    }
}
