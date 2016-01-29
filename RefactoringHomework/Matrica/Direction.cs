namespace MatrixWalk
{
    using System;

    public class Direction
    {
        private int x;
        private int y;

        public Direction(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            private set
            {
                if (value == 0 || value == 1 || value == -1)
                {
                    this.x = value;
                }
                else
                {
                     throw new ArgumentOutOfRangeException("posible value can be 0, 1, -1");
                }


            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            private set
            {
                if (value == 0 || value == 1 || value == -1)
                {
                    this.y = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("posible value can be 0, 1, -1");
                }
            }
        }
    }
}
