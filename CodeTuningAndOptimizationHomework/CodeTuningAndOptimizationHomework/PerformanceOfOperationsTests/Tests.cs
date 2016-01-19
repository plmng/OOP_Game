namespace PerformanceOfOperationsTests
{
    using System;

    public class TestBasicAritmeticOprations
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Bassic Arithmetics Tests:");
            Console.WriteLine("--------------------------");
            BasicAritmethics.RunTests();

            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nMathematic Functions Tests:");
            Console.WriteLine("-----------------------------");
            MathematicFunctions.RunTests();
            
        }
    }
}
