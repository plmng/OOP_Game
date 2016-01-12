namespace Problem1_ReformatCode
{
    using System;

    public class EventProgram
    {
        public static void Main(string[] args)
        {
            var messages = new Messages();
            var commandHandlerer = new CommandHandlerer();

            while (commandHandlerer.ExecuteNextCommand())
            {
            }

            Console.WriteLine(messages.Writer);
        }
    }
}