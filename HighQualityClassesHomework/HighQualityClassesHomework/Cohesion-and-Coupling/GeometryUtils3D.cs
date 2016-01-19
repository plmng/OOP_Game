namespace CohesionAndCoupling
{
    using System;
 
    public class GeometryUtils3D
    {
        private readonly IPoint3D originPoint3D = new Point3D(0,0,0);
       
        public double CalculateDistance3D(IPoint3D pointA, IPoint3D pointB)
        {
            double distance = Math.Sqrt(((pointB.X - pointA.X) * (pointB.X - pointA.X)) + ((pointB.Y - pointA.Y) * (pointB.Y - pointA.Y)) + ((pointB.Z - pointA.Z) * (pointB.Z - pointA.Z)));
            return distance;
        }

        public double CalculateVolume(IFigure3D figure)
        {
            double volume = figure.Width * figure.Height * figure.Depth;
            return volume;
        }

        public double CalculateDiagonal3D(IPoint3D point)
        {
            double distance = this.CalculateDistance3D(this.originPoint3D, point);
            return distance;
        }
    }
}
