namespace CohesionAndCoupling
{
    using System;

    public class GeometryUtils2D
    {
        private readonly IPoint2D originPoint = new Point2D(0 , 0);

        public double CalculateDistance2D(IPoint2D pointA, IPoint2D pointB)
        {
            double distance = Math.Sqrt(((pointB.X - pointA.X) * (pointB.X - pointA.X)) + ((pointB.Y - pointA.Y) * (pointB.Y - pointA.Y)));
            return distance;
        }

        public double CalculateDiagonal2D(IPoint2D point)
        {
            double distance = CalculateDistance2D(this.originPoint, point);
            return distance;
        }
    }
}
