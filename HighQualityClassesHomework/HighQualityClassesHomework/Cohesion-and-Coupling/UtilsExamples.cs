namespace CohesionAndCoupling
{
    using System;

    class UtilsExamples
    {
        static void Main()
        {
            var utilsFile = new FileUtils();
            var utilsGeometry2D = new GeometryUtils2D();
            var utilsGeometry3D = new GeometryUtils3D();

            Console.WriteLine(utilsFile.GetFileExtension("example"));
            Console.WriteLine(utilsFile.GetFileExtension("example.pdf"));
            Console.WriteLine(utilsFile.GetFileExtension("example.new.pdf"));

            Console.WriteLine(utilsFile.GetFileNameWithoutExtension("example"));
            Console.WriteLine(utilsFile.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(utilsFile.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", utilsGeometry2D.CalculateDistance2D(new Point2D(1, -2), new Point2D(3, 4)));
            Console.WriteLine("Distance in the 3D space = {0:f2}", utilsGeometry3D.CalculateDistance3D(new Point3D(5, 2, -1), new Point3D(3, -6, 4)));

            var x = 3;
            var y = 4;
            var z = 5;
            
            Figure3D figure = new Figure3D(x, y, z);
            IPoint3D pointXYZ = new Point3D(x, y, z);
            IPoint2D pointXY = new Point2D(x, y);
            IPoint2D pointXZ = new Point2D(x, z);
            IPoint2D pointYZ = new Point2D(y, z);

            Console.WriteLine("Volume = {0:f2}", utilsGeometry3D.CalculateVolume(figure));

            Console.WriteLine("Diagonal XYZ = {0:f2}", utilsGeometry3D.CalculateDiagonal3D(pointXYZ));
            Console.WriteLine("Diagonal XY = {0:f2}", utilsGeometry2D.CalculateDiagonal2D(pointXY));
            Console.WriteLine("Diagonal XZ = {0:f2}", utilsGeometry2D.CalculateDiagonal2D(pointXZ));
            Console.WriteLine("Diagonal YZ = {0:f2}", utilsGeometry2D.CalculateDiagonal2D(pointYZ));
        }
    }
}
