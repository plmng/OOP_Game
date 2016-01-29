namespace Logger.Core
{
    using System;

    public sealed class LoggerMessage
    {
        public LoggerMessage(DateTime date, ReportLevel reportLevel, string msg)
        {
            this.Date = date;
            this.ReportLevel = reportLevel;
            this.Message = msg;
        }

        public DateTime Date { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public string Message { get; private set; }
    }
}
