namespace Logger.Layouts
{
    using System;
    using System.IO;
    using Core;
    using Core.Interfaces;

    public class XmlLayout : ILayout
    {
        private readonly string spaceIndent = new string(' ', 4);

        public string GetFormatedMessage(LoggerMessage msg)
        {
            string formatedMsg = "<log>" + Environment.NewLine;

            formatedMsg += this.spaceIndent + "<date>" + msg.Date + "</date>" + Environment.NewLine;

            formatedMsg += this.spaceIndent + "<level>" + msg.ReportLevel + "</level>" + Environment.NewLine;

            formatedMsg += this.spaceIndent + "<message>" + msg.Message + "</message>" + Environment.NewLine;

            formatedMsg += "</log>";

            return formatedMsg;
        }
    }
}
