namespace Problem1_ReformatCode
{
    using System.Text;

    internal class Messages
    {
        private readonly StringBuilder _output = new StringBuilder();

        public StringBuilder Writer
        {
            get
            {
                return this._output;
            }
        }
        
        public void PrintEventAdded()
        {
            this._output.Append("Event added\n");
        }

        public void PrintEventDeleted(int x)
        {
            if (x == 0)
            {
                this.PrintNoEventsFound();
            }
            else
            {
                this._output.AppendFormat("{0} events deleted\n", x);
            }
        }

        public void PrintNoEventsFound()
        {
           this._output.Append("No events found\n");
        }

        public void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                this._output.Append(eventToPrint + "\n");
            }
        }
    }
}