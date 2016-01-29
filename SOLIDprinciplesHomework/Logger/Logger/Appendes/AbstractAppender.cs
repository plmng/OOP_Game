namespace Logger.Appendes
{
    using Core;
    using Core.Interfaces;

    public abstract class AbstractAppender : IAppender
    {
        protected AbstractAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public virtual void Append(LoggerMessage msg)
        {
            if (msg.ReportLevel <= this.ReportLevel)
            {
                return;
            }
        }
    }
}
