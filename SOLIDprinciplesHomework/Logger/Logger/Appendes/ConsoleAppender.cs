namespace Logger.Appendes
{
    using System;
    using Core;
    using Core.Interfaces;

    public class ConsoleAppender : AbstractAppender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }
        
        public override void Append(LoggerMessage msg)
        {
            string formatedMsg = this.Layout.GetFormatedMessage(msg);

            if (msg.ReportLevel >= this.ReportLevel)
            {
                Console.WriteLine(formatedMsg);
            }
        }
    }
}
