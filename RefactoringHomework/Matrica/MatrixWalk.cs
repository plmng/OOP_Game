namespace MatrixWalk
{
    using System;

    public class MatrixWalk
    {
       private readonly Direction[] posibleDirections = new[]
        {
            new Direction(1, 1), 
            new Direction(1, 0), 
            new Direction(1, -1), 
            new Direction(0, -1), 
            new Direction(-1, -1), 
            new Direction(-1, 0), 
            new Direction(-1, 1), 
            new Direction(0, 1)
        };

        private int col;
        private int directionIndex;
        private int fillingNumber;
        private int row;
        private int size;

        public MatrixWalk(int matrixSize)
        {
            this.Size = matrixSize;
            this.row = 0;
            this.col = 0;
            this.directionIndex = 0;
            this.fillingNumber = 1;
            this.Matrix = new int[matrixSize, matrixSize];
        }
        
        public int[,] Matrix { get; set; }
        
        private int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("matrixSize", "Matrix size has to be in the range [1..100]");
                }

                this.size = value;
            }
        }

        public void GetWalk()
        {
            this.Matrix[this.row, this.col] = this.fillingNumber;
            while (this.fillingNumber < this.Matrix.Length)
            {
                if (this.FindPosibleDirection())
                {
                    Direction direction = this.posibleDirections[this.directionIndex];
                    this.MoveInDirection(direction);
                    this.FillCell();
                }
                else
                {
                    if (this.fillingNumber < this.Matrix.Length)
                    {
                        this.FindEmptyCell();
                        this.FillCell();
                    }
                }
            }

            this.PrintMatrix();
        }

        private bool FindPosibleDirection()
        {
            bool isDirectionFound = false;

            for (int i = 0; i < this.posibleDirections.Length; i++)
            {
                if (!isDirectionFound)
                {
                    int nextRowIndex = this.row + this.posibleDirections[this.directionIndex].X;
                    int nextColIndex = this.col + this.posibleDirections[this.directionIndex].Y;
                    if (this.CheckForPosibleNextMove(nextRowIndex, nextColIndex))
                    {
                        isDirectionFound = true;
                    }
                    else
                    {
                        this.directionIndex++;
                        if (this.directionIndex >= this.posibleDirections.Length)
                        {
                            this.directionIndex = 0;
                        }
                    }
                }
            }

            return isDirectionFound;
        }

        private void MoveInDirection(Direction direction)
        {
            this.row += direction.X;
            this.col += direction.Y;
        }

        private void FillCell()
        {
            this.fillingNumber++;
            this.Matrix[this.row, this.col] = this.fillingNumber;
        }

        private void FindEmptyCell()
        {
            bool isEmtyCellFound = false;
            for (int rowIndex = 0; rowIndex < this.size; rowIndex++)
            {
                for (int colIndex = 0; colIndex < this.size; colIndex++)
                {
                    if (!isEmtyCellFound)
                    {
                        if (this.Matrix[rowIndex, colIndex] == 0)
                        {
                            isEmtyCellFound = true;
                            this.row = rowIndex;
                            this.col = colIndex;
                        }
                    }
                }
            }
        }

        private void PrintMatrix()
        {
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    Console.Write("{0,3}", this.Matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private bool CheckForPosibleNextMove(int row, int col)
        {
            if (row >= 0 && row < this.Size && col >= 0 && col < this.Size)
            {
                if (this.Matrix[row, col] == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}