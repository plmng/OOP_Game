namespace Methods
{
    using System;
    using Models;

    internal class ModelsExamples
    {
        private static void Main()
        {
            var calculator = new Calculations();
            Console.WriteLine(calculator.CalculateTriangleArea(3, 4, 5));
           
            Console.WriteLine(calculator.FindMax(5, -1, 3, 2, 14, 2, 3));
            
            double x1 = 3;
            double y1 = -1;
            double x2 = 3;
            double y2 = 2.5;
            Console.WriteLine(calculator.CalcDistance(x1, y1, x2, y2));
            Console.WriteLine("Horizontal? " + calculator.IsHorizontal(y1, y2));
            Console.WriteLine("Vertical? " + calculator.IsVertical(x1, x2));

            var displayer = new Displayings();
            
            Console.WriteLine(displayer.DisplayDigitAsWord(5));
            
            displayer.DisplayAsFormatedNumber(1.3, "f");
            displayer.DisplayAsFormatedNumber(0.75, "%");
            displayer.DisplayAsFormatedNumber(2.30, "r");

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");

            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");
            
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}