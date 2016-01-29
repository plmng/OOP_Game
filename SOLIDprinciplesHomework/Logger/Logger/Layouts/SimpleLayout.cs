namespace Logger.Layouts
{
    using Core;
    using Core.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string GetFormatedMessage(LoggerMessage msg)
        {
            string formatedMsg = string.Format("{0} - {1} - {2}", msg.Date, msg.ReportLevel, msg.Message);
            return formatedMsg;
        }
    }
}
