using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            var matrixA = new double[,]
            {
                { 1, 3, 2 }, 
                { 5, 7, 2 }
            };

            var matrixB = new double[,]
            {
                { 4, 2}, 
                { 1, 5},
                { 2, 2}
            };
            var resultMatrix = MatrixMultiplication(matrixA, matrixB);

            for (var row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (var column = 0; column < resultMatrix.GetLength(1); column++)
                {
                    Console.Write(resultMatrix[row, column] + " ");
                }
                Console.WriteLine();
            }

        }

        static double[,] MatrixMultiplication(double[,] matrixA, double[,] matrixB)
        {
           if (matrixA.GetLength(1) != matrixB.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var innerElements = matrixA.GetLength(1); 
            var matrixProductRows = matrixA.GetLength(0);
            var matrixProductColumns = matrixB.GetLength(1);

            var matrixProduct = new double[matrixProductRows, matrixProductColumns]; 
            for (var row = 0; row < matrixProductRows; row++)
                for (var column = 0; column < matrixProductColumns; column++)
                    for (var index = 0; index < innerElements; index++)
                    {
                        var elementMatrixA = matrixA[row, index];
                        var elementMatrixB = matrixB[index, column];
                        var dotProduct = elementMatrixA * elementMatrixB;
                        matrixProduct[row, column] += dotProduct;
                    }
            
            return matrixProduct;
        }
    }
}