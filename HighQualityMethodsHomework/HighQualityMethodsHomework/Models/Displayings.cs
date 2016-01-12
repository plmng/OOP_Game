namespace Methods.Models
{
    using System;

    public class Displayings
    {
        public string DisplayDigitAsWord(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentOutOfRangeException("number" + "Is not a digit!");
            }
        }

        public void DisplayAsFormatedNumber(object number, string format)
        {
            string formatToLower = format.ToLower();
            string formatedNumber;
            switch (formatToLower)
            {
                case "f":
                    formatedNumber = string.Format("{0:f2}", number);
                    break;
                case "%":
                    formatedNumber = string.Format("{0:p0}", number);
                    break;
                case "r":
                    formatedNumber = string.Format("{0,8}", number);
                    break;
                default: throw new ArgumentOutOfRangeException("format", "such format do not exist");
            }

            Console.WriteLine(formatedNumber);
        }
    }
}
