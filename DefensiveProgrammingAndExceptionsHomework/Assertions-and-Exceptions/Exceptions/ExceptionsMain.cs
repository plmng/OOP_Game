namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using StudentExamSystem;

    internal class ExceptionsMain
    {
        private static void Main()
        {
            Console.WriteLine("\nTest Utils.CheckPrime method");
            Utils.CheckPrime(23);
            Console.WriteLine("\nTest Utils.CheckPrime method");
            Utils.CheckPrime(33);

            try
            {
                Console.WriteLine("\nTest Utils.Subsequence method");
                var substring = Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substring);

                Console.WriteLine("\nTest Utils.Subsequence method");
                var subarray = Utils.Subsequence(new int[] {-1, 3, 2, 1}, 0, 2);
                Console.WriteLine(string.Join(" ", subarray));

                Console.WriteLine("\nTest Utils.ExtractEnding method");
                Console.WriteLine(Utils.ExtractEnding("I love C#", 2));

                Console.WriteLine("\nTest Utils.ExtractEnding method");
                Console.WriteLine(Utils.ExtractEnding("Nakov", 4));

                Console.WriteLine("\nTest Utils.ExtractEnding method");
                Console.WriteLine(Utils.ExtractEnding("beer", 4));


                Console.WriteLine("\nTest Exams Classes");
                List<IExam> peterExams = new List<IExam>()
                {
                    new SimpleMathExam(2),
                    new CSharpExam(55),
                    new CSharpExam(100),
                    new SimpleMathExam(1),
                    new CSharpExam(0),
                };
                Student peter = new Student("Peter", "Petrov", peterExams);

                double peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);



                // CRASH TESTS -> UNCOMENT TO TEST
                /*
                    Console.WriteLine("\nTest Utils.Subsequence method => should crash");
                    var allarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
                    Console.WriteLine(string.Join(" ", allarr));
                */

                /*
                    Console.WriteLine("\nTest Utils.Subsequence method => should crash");
                    var emptyarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                    Console.WriteLine(string.Join(" ", emptyarr));
                */

                /*
                    Console.WriteLine("\nTest Utils.ExtractEnding method => should crash");
                    Console.WriteLine(Utils.ExtractEnding("Hi", 100));
                */

                /*
                    Console.WriteLine("\nTest Exams Classes => should crach (on every row)");
                    new CSharpExam(-2);
                    new CSharpExam(300);
                    new SimpleMathExam(-2);
                    new SimpleMathExam(300);
               
                    Student dragancho = new Student("Dragancho", "Draganchev");
                    double peterAverageResult = dragancho.CalcAverageExamResultInPercents();
               */
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
