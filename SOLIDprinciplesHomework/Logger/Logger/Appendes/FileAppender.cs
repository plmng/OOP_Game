namespace Logger.Appendes
{
    using System.IO;
    using Core;
    using Core.Interfaces;

    public class FileAppender : AbstractAppender
    {
        public const string DefaultFile = "logger.txt";

        public FileAppender(ILayout layout)
            : base(layout)
        {
            this.File = DefaultFile;
        }

        public string File { get; set; }

        public override void Append(LoggerMessage msg)
        {
            base.Append(msg);

            string formatedMsg = this.Layout.GetFormatedMessage(msg);
            
            StreamWriter writer = new StreamWriter(this.File, true);
            using (writer)
            {
                writer.WriteLine(formatedMsg);
            }
        }
    }
}
