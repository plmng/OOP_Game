namespace Logger.Loggers
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Core.Interfaces;
   
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>();

            foreach (var appender in appenders)
            {
                this.appenders.Add(appender);
            }
        }

        public void Error(string msg)
        {
            this.SendMsgToAppenders(ReportLevel.Error, msg);
        }
        
        public void Info(string msg)
        {
            this.SendMsgToAppenders(ReportLevel.Info, msg);
        }

        public void Warn(string msg)
        {
           this.SendMsgToAppenders(ReportLevel.Warning, msg);
        }

        public void Fatal(string msg)
        {
            this.SendMsgToAppenders(ReportLevel.Fatal, msg);
        }

        public void Critical(string msg)
        {
            this.SendMsgToAppenders(ReportLevel.Critical, msg);
        }

        private void SendMsgToAppenders(ReportLevel reportLevel, string msg)
        {
            LoggerMessage msgToAppend = new LoggerMessage(DateTime.Now, reportLevel, msg);

            foreach (var appender in this.appenders)
            {
                appender.Append(msgToAppend);
            }
        }
    }
}
