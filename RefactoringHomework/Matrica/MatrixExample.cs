namespace MatrixWalk
{
    using System;
  
    internal class WalkInMatrica
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter number for matrix size in the range [1..100]");
            string input = Console.ReadLine();
            int size;
            if (!int.TryParse(input, out size))
            {
                throw new ArgumentException("For size have to be entered number.");
            }

            MatrixWalk matrix = new MatrixWalk(size);
            matrix.GetWalk();
        }
    }
}