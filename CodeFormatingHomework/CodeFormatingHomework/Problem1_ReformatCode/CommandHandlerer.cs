namespace Problem1_ReformatCode
{
    using System;

    public class CommandHandlerer
    {
        private readonly EventHolder _events = new EventHolder();

        internal bool ExecuteNextCommand()
        {
            var command = Console.ReadLine();
            if (command == null)
            {
                throw new NullReferenceException("no command entered"); 
            }

            switch (command[0])
            {
                case 'A':
                    this.AddEvent(command);
                    return true;
                case 'D':
                   this.DeleteEvents(command);
                    return true;
                case 'L':
                    this.ListEvents(command);
                    return true;
                case 'E':
                    return false;
            }

            return false;
        }

        private void ListEvents(string command)
        {
            var pipeIndex = command.IndexOf('|');
            var date = this.GetDate(command, "ListEvents");
            var countString = command.Substring(pipeIndex + 1);
            var count = int.Parse(countString);
            this._events.ListEvents(date, count);
        }

        private void DeleteEvents(string command)
        {
            var title = command.Substring("DeleteEvents".Length + 1);
            this._events.DeleteEvents(title);
        }

        private void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            this.GetParameters(command, "AddEvent", out date, out title, out location);
            this._events.AddEvent(date, title, location);
        }

        private void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = this.GetDate(commandForExecution, commandType);
            var firstPipeIndex = commandForExecution.IndexOf('|');
            var lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private DateTime GetDate(string command, string commandType)
        {
            var date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}
