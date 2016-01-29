namespace Logger.Core.Interfaces
{
    using Core;
   
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(LoggerMessage msg);
    }
}
