namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class Utils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr.Length == 0)
            {
                throw new ArgumentNullException("array", "the array is empty;");
            }

            if (startIndex < 0 || arr.Length <= startIndex)
            {
                throw new ArgumentOutOfRangeException("startIndex", "start index can not be less than 0 or grater than array length");
            }

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("count", "count can not be negative number or zero");
            }

            if (arr.Length <= startIndex + count)
            {
                throw new ArgumentOutOfRangeException("startIndex and count", "the elements to extract are more than array has");
            }
            
            List<T> result = new List<T>();
            
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (str.Length < count)
            {
                throw new ArgumentOutOfRangeException("count", "invalid count");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            bool isPrime = true;

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                }
            }

            if (isPrime)
            {
                Console.WriteLine("the number {0} is prime", number);
            }
            else
            {
                Console.WriteLine("the number {0} is not prime", number);
            }
        }
    }
}
