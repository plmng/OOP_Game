namespace CohesionAndCoupling
{
    public class Point2D : IPoint2D
    {
        private readonly double x;

        private readonly double y;

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return this.x; } 
        }

        public double Y
        {
            get { return this.y; }
        }
    }
}
