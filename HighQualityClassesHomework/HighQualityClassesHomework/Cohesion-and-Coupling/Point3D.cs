namespace CohesionAndCoupling
{
    public class Point3D : IPoint3D
    {
        private readonly double x;

        private readonly double y;

        private readonly double z;

        public Point3D(double x, double y, double z) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public double X
        {
            get { return this.x; } 
        }

        public double Y
        {
            get { return this.y; }
        }

        public double Z
        {
            get { return this.z; }
        }
    }
}
