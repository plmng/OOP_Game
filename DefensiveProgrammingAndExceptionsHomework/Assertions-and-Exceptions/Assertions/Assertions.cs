namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    internal class Assertions
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr.Length <= 0, "The array cannot be empty.");
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr.Length <= 0, "The array cannot be empty.");
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Length <= 0, "The array cannot be empty.");
            Debug.Assert(arr.Length <= startIndex, "The Start Index cannot be greater than array length");
            Debug.Assert(arr.Length <= endIndex, "The End Index cannot be greater than array length.");
            Debug.Assert(arr.Length <= 0, "The array cannot be empty.");
            Debug.Assert(startIndex < 0, "The Start Index cannot be negative.");
            Debug.Assert(endIndex < 0, "The End Index cannot be negative.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Length <= 0, "The array cannot be empty.");
            Debug.Assert(arr.Length <= startIndex, "The Start Index cannot be greater than array length");
            Debug.Assert(arr.Length <= endIndex, "The End Index cannot be greater than array length.");
            Debug.Assert(arr.Length <= 0, "The array cannot be empty.");
            Debug.Assert(startIndex < 0, "The Start Index cannot be negative.");
            Debug.Assert(endIndex < 0, "The End Index cannot be negative.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
