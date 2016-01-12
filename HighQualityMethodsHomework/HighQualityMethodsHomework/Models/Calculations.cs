namespace Methods.Models
{
    using System;

    internal class Calculations
    {
        public double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0)
            {
                throw new ArgumentOutOfRangeException("sideA", "Sides should be positive numbers bigger than 0");
            }

            if (sideB <= 0)
            {
                throw new ArgumentOutOfRangeException("sideB", "Sides should be positive numbers bigger than 0");
            }

            if (sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("sideC", "Sides should be positive numbers bigger than 0");
            }

            double perimeter = sideA + sideB + sideC;
            double s = perimeter / 2;
            double area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));

            return area;
        }

        public int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("elements", "the input array is empty");
            }

            int maxElementValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (maxElementValue < elements[i])
                {
                    maxElementValue = elements[i];
                }
            }

            return maxElementValue;
        }

        public double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = Equals(y1, y2);
            return isHorizontal;
        }

        public bool IsVertical(double x1, double x2)
        {
            bool isVertical = Equals(x1, x2);
            return isVertical;
        }
    }
}
