
public class Point
{
    public Point(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public double X { get; set; }

    public double Y { get; set; }

    public double ComputeDistanceTo(Point other)
    {
        // The square of the Eucledian distance can also be used, there is no need
        // to take the square root of this expression (and it is faster)
        double deltaX = other.X - this.X;
        double deltaY = other.Y - this.Y;
        
        return deltaX * deltaX + deltaY * deltaY;
    }
}
