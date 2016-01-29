namespace MatrixWalk.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixWalkTests
    {
        [TestMethod]
        public void GetWalkShouldReturnCorrectMatrix()
        {
            // Arrange 
            MatrixWalk matrixWalk = new MatrixWalk(5);
            List<int>[] expextedMatrix = new List<int>[5];
            expextedMatrix[0] = new List<int>() { 1, 13, 14, 15, 16 };
            expextedMatrix[1] = new List<int>() { 12, 2, 21, 22, 17 };
            expextedMatrix[2] = new List<int>() { 11, 23, 3, 20, 18 };
            expextedMatrix[3] = new List<int>() { 10, 25, 24, 4, 19 };
            expextedMatrix[4] = new List<int>() { 9, 8, 7, 6, 5 };
           
            // Act
            matrixWalk.GetWalk();

            // Assert
           // Assert.AreEqual(expextedMatrix, matrixWalk.Matrix);
            for (int row = 0; row < 5; row++)
            {
                var expextedRow = expextedMatrix[row];
                for (int col = 0; col < 5; col++)
                {
                    Assert.AreEqual(expextedRow[col], matrixWalk.Matrix[row, col]);
                }
            }
        }
    }
}
