namespace Breakout.Contracts
{
    public interface IWall
    {
        int Height { get; }

        int Width { get; }

        IBrick[,] FilledWall { get; }

        IFillingPattern FillingPattern { get; }

        void DrawWall();

        void UpdateWall(int x, int y);
    }
}
